using DemoToolkit.Mvvm.DesktopGeneric;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using TaskTamer.ViewModels.Services;

namespace DemoToolkit.Mvvm.WinForms.Services;

public interface IWinFormsStartService : IApplicationStartService
{
    [AllowNull]
    public static ServiceProvider ServiceProvider { get; private set; }
    public static IServiceCollection Services { get; private set; }

    private static readonly Dictionary<Type, Func<Form>> s_viewFactories;

    static IWinFormsStartService()
    {
        s_viewFactories = [];
        Services = new ServiceCollection();
    }

    private static void ConfigureServices()
    {
        // Register ViewLocator Service.
        Services.AddSingleton<IViewLocatorService<Form>, WinFormsViewLocator>();

        // SyncContext Service
        Services.AddSingleton<ISyncContextService, SyncContextService>();

        // ViewModel Factory
        Services.AddSingleton<IViewModelFactoryService, ViewModelFactory>();

        // Dialog Service
        Services.AddSingleton<IMvvmDialogService, WinFormsDialogService>();
    }

    public static void SetStartViewModel<TStartViewModel>()
        where TStartViewModel : class, INotifyPropertyChanged
    {
        ConfigureServices();
        Services.AddTransient<IApplicationStartService, ApplicationStartService<TStartViewModel>>();
    }

    public static void Run()
    {
        ServiceProvider = Services.BuildServiceProvider();

        var viewLocator = ServiceProvider.GetRequiredService<IViewLocatorService<Form>>() as WinFormsViewLocator;

        // Let's register the views now in the ViewLocator:
        viewLocator!.SetViewLookup(s_viewFactories);

        var startService = ServiceProvider.GetRequiredService<IApplicationStartService>();
        startService.StartApplication();
    }

    public static void RegisterView<TViewModel>(Func<Form> viewFactory)
        where TViewModel : class, INotifyPropertyChanged
    {
        Type viewModelType = typeof(TViewModel);

        if (s_viewFactories.ContainsKey(viewModelType))
        {
            throw new InvalidOperationException($"View factory already registered for ViewModel type {viewModelType.Name}.");
        }

        s_viewFactories.Add(viewModelType, viewFactory);

        // Register the ViewModel in the ServiceCollection
        Services.AddTransient<TViewModel>();
    }
}
