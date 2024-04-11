using System.ComponentModel;
using TimeTamer.Generic.UIService;

namespace CommunityToolkit.Mvvm.WinForms;

public class ApplicationStartService<TViewModel>(IViewLocator<Form> viewLocator, IViewModelFactory viewModelFactory) 
    : IApplicationStartService
    where TViewModel : class, INotifyPropertyChanged
{
    public void StartApplication()
    {
        // Assuming your view locator and view model factory are properly set up to work with these methods
        var mainViewModel = viewModelFactory.CreateViewModel<TViewModel>();
        var mainView = viewLocator.CreateView(mainViewModel);

        // Ensure mainView is a Form or adapt as necessary
        Application.Run(mainView as Form); 
    }
}
