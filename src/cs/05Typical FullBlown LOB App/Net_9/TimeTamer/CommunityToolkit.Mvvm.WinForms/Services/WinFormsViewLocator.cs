using System.Windows.Forms;
using TaskTamer.Generic.UIService;

namespace CommunityToolkit.Mvvm.WinForms;

public class WinFormsViewLocator : IViewLocator<Form>
{
    private Dictionary<Type, Func<Form>> viewFactories;

    public WinFormsViewLocator()
    {
        viewFactories = [];
    }

    internal void SetViewLookup(Dictionary<Type, Func<Form>> viewLookUp)
    {
        viewFactories = viewLookUp;
    }

    Form IViewLocator<Form>.CreateView<TViewModel>(TViewModel viewModel)
    {
        Type viewModelType = typeof(TViewModel);

        if (!viewFactories.TryGetValue(viewModelType, out var viewFactory))
        {
            throw new InvalidOperationException($"No view factory found for ViewModel type {viewModelType.Name}.");
        }

        Form view = viewFactory();
        view.DataContext = viewModel;

        return view;
    }

    void IViewLocator<Form>.Register<TViewModel>(Func<Form> viewFactory)
    {
        Type viewModelType = typeof(TViewModel);

        if (viewFactories.ContainsKey(viewModelType))
        {
            throw new InvalidOperationException($"View factory already registered for ViewModel type {viewModelType.Name}.");
        }

        viewFactories.Add(viewModelType, viewFactory);
    }
}
