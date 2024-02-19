using System.Globalization;

namespace AutoColumnListViewDemo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Change the locale for testing purposes to German:
            Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");

            // Change the UI culture for testing purposes to German:
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");

            using FrmMain frmMain = new();
            Application.Run(frmMain);
        }
    }
}
