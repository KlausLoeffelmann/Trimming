using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using TimeTamer.Generic.UIService;

namespace TimeTamer.ViewModels.Services;

public class ViewModelFactory(IServiceProvider serviceProvider) : IViewModelFactory
{
    public TViewModel CreateViewModel<TViewModel>() where TViewModel 
        : class, INotifyPropertyChanged
    {
        return serviceProvider.GetRequiredService<TViewModel>();
    }
}