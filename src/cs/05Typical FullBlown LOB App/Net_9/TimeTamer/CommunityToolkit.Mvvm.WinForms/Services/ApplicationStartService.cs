using DemoToolkit.Mvvm.DesktopGeneric;
using System.ComponentModel;

namespace DemoToolkit.Mvvm.WinForms.Services;

/// <summary>
///  Service for starting a WinForms application with a specified view model.
/// </summary>
/// <typeparam name="TViewModel">The type of the view model.</typeparam>
public class ApplicationStartService<TViewModel> : IWinFormsStartService
    where TViewModel : class, INotifyPropertyChanged
{
    private readonly IViewModelFactoryService _viewModelFactory;
    private readonly IViewLocatorService<Form> _viewLocator;
    private readonly ISyncContextService _syncContextService;
    private readonly IMvvmDialogService _dialogService;

    /// <summary>
    ///  Initializes a new instance of the <see cref="ApplicationStartService{TViewModel}"/> class.
    /// </summary>
    /// <param name="viewLocator">The view locator.</param>
    /// <param name="viewModelFactory">The view model factory.</param>
    /// <param name="syncContextService">The synchronization context service.</param>
    public ApplicationStartService(
        IViewLocatorService<Form> viewLocator, 
        IViewModelFactoryService viewModelFactory, 
        ISyncContextService syncContextService,
        IMvvmDialogService dialogService)
    {
        _viewModelFactory = viewModelFactory;
        _viewLocator = viewLocator;
        _syncContextService = syncContextService;
        _dialogService = dialogService;
    }

    /// <summary>
    ///  Starts the WinForms application.
    /// </summary>
    public void StartApplication()
    {
        // Assuming your view locator and view model factory are properly set up to work with these methods
        var mainViewModel = _viewModelFactory.CreateViewModel<TViewModel>();
        var mainView = _viewLocator.CreateView(mainViewModel);

        mainView.DataContext = mainViewModel;
        mainView.Load += MainView_RegisterSynchronizationContext;

        // Ensure mainView is a Form or adapt as necessary
        Application.Run(mainView as Form);
    }

    private void MainView_RegisterSynchronizationContext(object? sender, EventArgs e)
    {
        if (sender is Form form)
        {
            ((SyncContextService)_syncContextService).RegisterSyncContext(WindowsFormsSynchronizationContext.Current!);

            // Unregister the event handler
            form.Load -= MainView_RegisterSynchronizationContext;
        }
    }
}
