﻿using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using TimeTamer.Generic.UIService;
using TimeTamer.ViewModels.Services;

namespace CommunityToolkit.Mvvm.WinForms;

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
        // AutoMapper configuration.
        Services.AddAutoMapper(Assembly.GetEntryAssembly());

        // Register ViewLocator Service.
        Services.AddSingleton<IViewLocator<Form>, WinFormsViewLocator>();

        // ViewModel Factory
        Services.AddSingleton<IViewModelFactory, ViewModelFactory>();

        Services.AddSingleton<ISyncContextService, SyncContextService>();
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

        var viewLocator = ServiceProvider.GetRequiredService<IViewLocator<Form>>() as WinFormsViewLocator;

        // Let's register the views now in the ViewLocator:
        viewLocator!.SetViewLookup(s_viewFactories);

        // TODO: Pass the actual Form.
        Application.Run();
    }

    public static void RegisterView<TViewModel>(Func<Form> viewFactory)
    {
        Type viewModelType = typeof(TViewModel);

        if (s_viewFactories.ContainsKey(viewModelType))
        {
            throw new InvalidOperationException($"View factory already registered for ViewModel type {viewModelType.Name}.");
        }

        s_viewFactories.Add(viewModelType, viewFactory);
    }
}
