using System.ComponentModel;

namespace CommunityToolkit.Mvvm.DesktopGeneric;

public interface IViewModelFactory
{
    TViewModel CreateViewModel<TViewModel>() where TViewModel : class, INotifyPropertyChanged;
}
