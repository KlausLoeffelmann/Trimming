using TimeTamer.ViewModels;
using TimeTamer9.WinForms.Views;
using static CommunityToolkit.Mvvm.WinForms.IWinFormsStartService;

namespace TimeTamer.WinForms;

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

        // We're registering the ViewModels and the view here:
        RegisterView<TaskViewModel>(() => new FrmManageProjects());
        RegisterView<TimeTamerMainViewModel>(() => new FrmTimeTamerMain());

        // We're setting the start ViewModel here:
        SetStartViewModel<TimeTamerMainViewModel>();

        // Let's go!
        Run();
    }
}
