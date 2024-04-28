using System.ComponentModel;

namespace DemoToolkit.Mvvm.DesktopGeneric;

public interface IViewModelFactoryService
{
    TViewModel CreateViewModel<TViewModel>() where TViewModel : class, INotifyPropertyChanged;
}
