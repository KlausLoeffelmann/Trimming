using System.ComponentModel;

namespace CommunityToolkit.Mvvm.DesktopGeneric;

public interface IViewModelFactoryService
{
    TViewModel CreateViewModel<TViewModel>() where TViewModel : class, INotifyPropertyChanged;
}
