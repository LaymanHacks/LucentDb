using System;
using System.IO;
using System.Windows.Forms;

namespace LucentDb.Win.UI
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var dirPath = Path.GetFullPath(Application.StartupPath + "../LucentDb.Web.UI/App_Data/");
            AppDomain.CurrentDomain.SetData("DataDirectory", dirPath);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}