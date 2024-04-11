using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TimeTamer.WinForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            // Register services
            services.AddSingleton<IMyService, MyService>();

            // Register ViewModels
            services.AddTransient<MainViewModel>();

            // Build the provider
            var serviceProvider = services.BuildServiceProvider();

            // Set the default service provider for the MVVM Toolkit
            Ioc.Default.ConfigureServices(serviceProvider);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
