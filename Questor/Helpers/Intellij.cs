using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using Questor.Exceptions;
using Questor.Extensions;

namespace Questor.Helpers
{
    public static  class Intellij
    {
        public static void OpenIntellij(string intellijConfig, string file, int linenr)
        {
            string intellij;
            if (string.IsNullOrEmpty(intellijConfig))
            {
                intellij = FindIntelliJ();
            }
            else
            {
                intellij = intellijConfig;
            }
            if (string.IsNullOrEmpty(intellij))
            {
                MessageBox.Show("Cannot find intellij.");
                return;
            }
            if (!File.Exists(file))
            {
                MessageBox.Show($"Can not find file {file}");
                return;
            }

            string arguments;
            if (linenr >= 0)
            {
                arguments = $"--line {linenr} {file}";
            }
            else
            {
                arguments = file;
            }
            ProcessStartInfo psi = new ProcessStartInfo(intellij, arguments);
            Process process = Process.Start(psi);
            Catch.All(() =>
            {
                if (process?.HasExited == false)
                {
                    process?.WaitForInputIdle(1000);
                }
            });
            ProcessEx.BringMainWindowToFront("idea64");
        }

        private static string _intellij;
     

        private static string FindIntelliJ()
        {
            if (!string.IsNullOrEmpty(_intellij))
            {
                return _intellij;
            }
            if (_intellij == "")
            {
                return null;
            }

            _intellij = Directory.GetFiles(@"C:\Program Files\JetBrains", "idea64.exe", SearchOption.AllDirectories).FirstOrDefault();
            if (_intellij == null)
            {
                _intellij = Directory.GetFiles(@"C:\JetBrains", "idea64.exe", SearchOption.AllDirectories).FirstOrDefault();
            }
            if (_intellij == null)
            {
                _intellij = "";
                return null;
            }

            return _intellij;
        }
    }
}