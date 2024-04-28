using DemoToolkit.Mvvm.DesktopGeneric;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace TaskTamer.ViewModels.Services;

public class ViewModelFactory(IServiceProvider serviceProvider) : IViewModelFactoryService
{
    public TViewModel CreateViewModel<TViewModel>() where TViewModel 
        : class, INotifyPropertyChanged
    {
        return serviceProvider.GetRequiredService<TViewModel>();
    }
}