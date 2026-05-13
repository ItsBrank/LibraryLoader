using System;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;

// https://www.pinvoke.net/default.aspx/kernel32.openprocess
// https://www.pinvoke.net/default.aspx/kernel32.virtualallocex

namespace LibraryLoader.Framework
{
    public enum InjectionResults : byte
    {
        None,
        UnhandledException,
        LibraryNotFound,
        ProcessNotFound,
        AlreadyInjected,
        HandleNotFound,
        KernelNotFound,
        LoadLibraryNotFound,
        AllocateFail,
        WriteFail,
        ThreadFail,
        Success
    }

    [Flags]
    public enum ProcessFlags : UInt32
    {
        All = 0x001F0FFF,
        Terminate = 0x00000001,
        CreateThread = 0x00000002,
        VirtualMemoryOperation = 0x00000008,
        VirtualMemoryRead = 0x00000010,
        VirtualMemoryWrite = 0x00000020,
        DuplicateHandle = 0x00000040,
        CreateProcess = 0x000000080,
        SetQuota = 0x00000100,
        SetInformation = 0x00000200,
        QueryInformation = 0x00000400,
        QueryLimitedInformation = 0x00001000,
        Synchronize = 0x00100000
    }

    [Flags]
    public enum AllocationType : UInt32
    {
        Commit = 0x1000,
        Reserve = 0x2000,
        Decommit = 0x4000,
        Release = 0x8000,
        Reset = 0x80000,
        Physical = 0x400000,
        TopDown = 0x100000,
        WriteWatch = 0x200000,
        LargePages = 0x20000000
    }

    [Flags]
    public enum MemoryProtection : UInt32
    {
        Execute = 0x10,
        ExecuteRead = 0x20,
        ExecuteReadWrite = 0x40,
        ExecuteWriteCopy = 0x80,
        NoAccess = 0x01,
        ReadOnly = 0x02,
        ReadWrite = 0x04,
        WriteCopy = 0x08,
        GuardModifierflag = 0x100,
        NoCacheModifierflag = 0x200,
        WriteCombineModifierflag = 0x400
    }

    public static class FLoader
    {
        private static List<IntPtr> m_handleCache = new List<IntPtr>(); // Handle cache for processes we've already loaded into.

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, UInt32 nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, UInt32 dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, UInt32 dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, AllocationType flAllocationType, MemoryProtection flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(ProcessFlags dwDesiredAccess, bool bInheritHandle, UInt32 dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern Int32 CloseHandle(IntPtr hObject);

        public static void ClearHandleCache()
        {
            m_handleCache.Clear();
        }

        public static bool IsModuleLoaded(Process process, string keyword, bool bForceCheck)
        {
            if (FProcess.IsValidProcess(process))
            {
                if (bForceCheck)
                {
                    List<ProcessModule> moudles = FProcess.GetModules(process);

                    foreach (ProcessModule module in moudles)
                    {
                        if (module.FileName.Contains(keyword))
                        {
                            if (!m_handleCache.Contains(process.Handle))
                            {
                                m_handleCache.Add(process.Handle);
                            }

                            return true;
                        }
                    }
                }
                else
                {
                    return m_handleCache.Contains(process.Handle);
                }
            }

            return false;
        }

        // Attempts to load a library into an individual process, adds to the "m_handleCache" list but does NOT remove old handles.
        public static InjectionResults LoadLibrary(Process process, string libraryFile)
        {
            if (File.Exists(libraryFile))
            {
                if (FProcess.IsValidProcess(process))
                {
                    if (!IsModuleLoaded(process, Path.GetFileNameWithoutExtension(libraryFile), false))
                    {
                        InjectionResults result = LoadLibraryInternal(process, libraryFile);

                        if (result == InjectionResults.Success)
                        {
                            m_handleCache.Add(process.Handle);
                        }

                        return result;
                    }
                    else
                    {
                        return InjectionResults.AlreadyInjected;
                    }
                }
                else
                {
                    return InjectionResults.ProcessNotFound;
                }
            }

            return InjectionResults.LibraryNotFound;
        }

        private static InjectionResults LoadLibraryInternal(Process process, string libraryFile)
        {
            IntPtr processHandle = IntPtr.Zero;
            IntPtr threadHandle = IntPtr.Zero;

            try
            {
                if (!File.Exists(libraryFile))
                {
                    return InjectionResults.LibraryNotFound;
                }

                processHandle = OpenProcess((ProcessFlags.CreateThread | ProcessFlags.QueryInformation | ProcessFlags.VirtualMemoryOperation | ProcessFlags.VirtualMemoryWrite | ProcessFlags.VirtualMemoryRead), false, (UInt32)process.Id);

                if (processHandle == IntPtr.Zero)
                {
                    return InjectionResults.HandleNotFound;
                }

                IntPtr kernel32Handle = GetModuleHandle("kernel32.dll");

                if (kernel32Handle == IntPtr.Zero)
                {
                    return InjectionResults.KernelNotFound;
                }

                IntPtr loadLibraryAddress = GetProcAddress(kernel32Handle, "LoadLibraryW");

                if (loadLibraryAddress == IntPtr.Zero)
                {
                    return InjectionResults.LoadLibraryNotFound;
                }

                byte[] libraryBytes = Encoding.Unicode.GetBytes(libraryFile + '\0');
                IntPtr allocateBuffer = VirtualAllocEx(processHandle, IntPtr.Zero, new IntPtr(libraryBytes.Length), (AllocationType.Commit | AllocationType.Reserve), MemoryProtection.ReadWrite);

                if (allocateBuffer == IntPtr.Zero)
                {
                    return InjectionResults.AllocateFail;
                }

                IntPtr bytesWritten = 0;
                bool writeSuccess = WriteProcessMemory(processHandle, allocateBuffer, libraryBytes, (UInt32)libraryBytes.Length, out bytesWritten);

                if (!writeSuccess || (bytesWritten.ToInt64() != libraryBytes.Length))
                {
                    return InjectionResults.WriteFail;
                }

                threadHandle = CreateRemoteThread(processHandle, IntPtr.Zero, 0, loadLibraryAddress, allocateBuffer, 0, IntPtr.Zero);

                if (threadHandle == IntPtr.Zero)
                {
                    return InjectionResults.ThreadFail;
                }

                return InjectionResults.Success;
            }
            catch
            {
                return InjectionResults.UnhandledException;
            }
            finally
            {
                if (threadHandle != IntPtr.Zero)
                {
                    CloseHandle(threadHandle);
                }

                if (processHandle != IntPtr.Zero)
                {
                    CloseHandle(processHandle);
                }
            }
        }
    }
}
