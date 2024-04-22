using TaskTamer.ViewModels;
using TaskTamer.WinForms.Views;
using static CommunityToolkit.Mvvm.WinForms.IWinFormsStartService;

namespace TaskTamer.WinForms;

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

        //Application.SetDefaultDarkMode(DarkMode.Inherits);

        // We're registering the ViewModels and the view here:
        RegisterView<TaskViewModel>(() => new FrmManageProjects());
        RegisterView<TaskTamerMainViewModel>(() => new FrmTaskTamerMain());

        // We're setting the start ViewModel here:
        SetStartViewModel<TaskTamerMainViewModel>();

        // Let's go!
        Run();
    }
}
