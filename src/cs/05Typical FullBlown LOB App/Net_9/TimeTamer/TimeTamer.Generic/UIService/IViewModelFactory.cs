using System.ComponentModel;

namespace TimeTamer.Generic.UIService;

public interface IViewModelFactory
{
    TViewModel CreateViewModel<TViewModel>() where TViewModel : class, INotifyPropertyChanged;
}
