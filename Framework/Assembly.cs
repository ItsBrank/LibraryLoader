using System;

namespace LibraryLoader.Framework
{
    public static class Assembly
    {
        private static readonly bool m_x64Bit = false;
        private static readonly string m_title = "ItsBrank's Library Loader";
        private static readonly string m_version = "1.4";

        public static bool Is64Bit() { return m_x64Bit; }
        public static string GetTitle() { return (m_title + (Is64Bit() ? " (x64)" : " (x86)")); }
        public static string GetVersion() { return m_version; }
    }
}