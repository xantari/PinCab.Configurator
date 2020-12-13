using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinCab.ScreenUtil.Models.PinballY
{
    public class PinballYSystem
    {
        public PinballYSystem() { }
        /// <summary>
        /// System #
        /// </summary>
        public int Id { get; set; }
        //System1, System2, etc variable
        public string Name { get; set; }
        public string Class { get; set; }
        public string MediaDir { get; set; }
        public string DatabaseDir { get; set; }
        public string Exe { get; set; }
        /// <summary>
        /// #   SW_SHOW          - shows the window normally
        /// #   SW_SHOWMINIMIZED - shows the window minimized to the task bar
        /// #   SW_HIDE          - hides the window
        /// </summary>
        public string ShowWindow { get; set; }
        public string Environment { get; set; }
        public string TablePath { get; set; }
        public string Parameters { get; set; }
        public string DefExt { get; set; }
        public bool Enabled { get; set; }
        public string RunBeforePre { get; set; }
        public string RunBefore { get; set; }
        public string RunAfter { get; set; }
        public string RunAfterPost { get; set; }
        public string Process { get; set; }
        public string DOFTitlePrefix { get; set; }
        public string TerminateBy { get; set; }
        public string StartupKeys { get; set; }
        public string NVRAMPath { get; set; }
        public string ShowWindowsWhileRunning { get; set; }
    }
}
