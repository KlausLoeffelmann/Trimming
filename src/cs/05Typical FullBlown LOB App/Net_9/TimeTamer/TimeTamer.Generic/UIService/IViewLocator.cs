using System.ComponentModel;

namespace TimeTamer.Generic.UIService;

public interface IViewLocator<TView>
    where TView : class
{
    TView CreateView<TViewModel>(TViewModel viewModel)
        where TViewModel : class, INotifyPropertyChanged;

    void Register<TViewModel>(Func<TView> viewFactory)
        where TViewModel : class, INotifyPropertyChanged;
}
