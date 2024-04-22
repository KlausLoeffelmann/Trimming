using System.ComponentModel;

namespace TaskTamer.Generic.UIService;

public interface IViewModelFactory
{
    TViewModel CreateViewModel<TViewModel>() where TViewModel : class, INotifyPropertyChanged;
}
