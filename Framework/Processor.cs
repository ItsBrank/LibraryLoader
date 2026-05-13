using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LibraryLoader.Framework
{
    public static class FProcess
    {
        [DllImport("ntdll.dll", PreserveSig = false)] public static extern void NtSuspendProcess(IntPtr processHandle);
        [DllImport("ntdll.dll", PreserveSig = false, SetLastError = true)] public static extern void NtResumeProcess(IntPtr processHandle);

        public static bool IsValidProcess(Process process)
        {
            try
            {
                if ((process != null)
                    && (process.Id > 8) // A process with an id of 8 or lower is a system process, we shouldn't be trying to access those.
                    && (process.MainWindowHandle != IntPtr.Zero))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Most likely an access denied exception, which we don't need to do anything for.
            }

            return false;
        }

        public static List<Process> GetAllProcesses()
        {
            List<Process> returnList = new List<Process>();
            Process[] processList = Process.GetProcesses();

            foreach (Process process in processList)
            {
                if (IsValidProcess(process))
                {
                    returnList.Add(process);
                }
            }

            return returnList;
        }

        public static Process? GetProcess(decimal pid)
        {
            return GetProcess((Int32)pid);
        }

        public static Process? GetProcess(Int32 pid)
        {
            Process[] processList = Process.GetProcesses();

            foreach (Process process in processList)
            {
                if (process.Id == pid)
                {
                    return process;
                }
            }

            return null;
        }

        public static Process? GetProcess(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                Process[] processList = Process.GetProcesses();

                foreach (Process process in processList)
                {
                    if ((process.MainWindowTitle == keyword) || (process.ProcessName == keyword))
                    {
                        return process;
                    }
                }
            }

            return null;
        }

        public static List<ProcessModule> GetModules(Process process)
        {
            List<ProcessModule> returnList = new List<ProcessModule>();

            if (IsValidProcess(process))
            {
                foreach (ProcessModule module in process.Modules)
                {
                    if ((module != null) && (module.BaseAddress != IntPtr.Zero))
                    {
                        returnList.Add(module);
                    }
                }
            }

            return returnList;
        }

        public static void Close(Process process)
        {
            if (IsValidProcess(process))
            {
                process.Kill();
            }
        }

        public static void Suspend(Process process)
        {
            if (IsValidProcess(process))
            {
                NtSuspendProcess(process.Handle);
            }
        }

        public static void Resume(Process process)
        {
            if (IsValidProcess(process))
            {
                NtResumeProcess(process.Handle);
            }
        }
    }
}
