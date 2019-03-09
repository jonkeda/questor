using System;
using System.Diagnostics;
using System.Reflection;

namespace Questor.Helpers
{
    public static class AssemblyFileVersionHelper
    {
        public static string GetShortVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            Version v = new Version(fvi.FileVersion);
            return $"{v.Major}.{v.Minor}";
        }
    }

}
