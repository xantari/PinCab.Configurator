using Microsoft.Win32;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.Utils.Utils
{
    /// <summary>
    /// https://stackoverflow.com/questions/16316827/how-to-export-a-registry-in-c-sharp
    /// </summary>
    public static class RegistryUtil
    {
        public static void ExportViaRegEditExe(string exportPath, string registryPath)
        {
            string path = "\"" + exportPath + "\"";
            string key = "\"" + registryPath + "\"";
            Process proc = new Process();

            try
            {
                proc.StartInfo.FileName = "regedit.exe";
                proc.StartInfo.UseShellExecute = false;

                proc = Process.Start("regedit.exe", "/e " + path + " " + key);
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error during regedit.exe export");
                proc.Dispose();
            }
        }
        public static void ExportViaRegExe(string strKey, string filepath)
        {
            try
            {
                using (Process proc = new Process())
                {
                    proc.StartInfo.FileName = "reg.exe";
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardError = true;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.StartInfo.Arguments = "export \"" + strKey + "\" \"" + filepath + "\" /y";
                    proc.Start();
                    string stdout = proc.StandardOutput.ReadToEnd();
                    string stderr = proc.StandardError.ReadToEnd();
                    proc.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error during reg.exe export");
            }
        }

        /// <summary>
        /// Check if user account control is enabled
        /// https://documentation.solarwindsmsp.com/N-central/documentation/Content/Automation/Policies/Diagnostics/pol_UACEnabled_Check.htm
        /// </summary>
        /// <returns></returns>
        public static bool CheckIfUacEnabled()
        {
            var key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            var keyVal = key.GetValue("EnableLUA")?.ToString();
            key.Close();

            if (!string.IsNullOrEmpty(keyVal) && keyVal != "0")
                return true; //UAC enabled

            var key2 = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            var keyVal2 = key.GetValue("ConsentPromptBehaviorAdmin")?.ToString();
            key2.Close();

            if (!string.IsNullOrEmpty(keyVal2) && keyVal2 != "0")
                return true; //UAC enabled

            return false;
        }
    }
}
