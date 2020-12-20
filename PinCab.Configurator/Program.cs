using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PinCab.Configurator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("Logs\\log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Application Started. Version: {version}", Assembly.GetExecutingAssembly().GetName().Version.ToString());

            Application.Run(new MainForm());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Log.Error("Thread Exception occurred. {ex}", e.Exception);
            var dialog = new ThreadExceptionDialog(e.Exception);
            var result = dialog.ShowDialog();
            if (result == DialogResult.Abort)
                Application.Exit();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Log.Error("Unhandled Exception occurred. {ex}", ex);
            //if (e.IsTerminating)
            //    Log.CloseAndFlush();
        }
    }
}
