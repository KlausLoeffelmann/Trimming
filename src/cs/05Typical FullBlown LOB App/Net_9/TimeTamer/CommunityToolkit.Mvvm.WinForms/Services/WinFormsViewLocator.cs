using DemoToolkit.Mvvm.DesktopGeneric;

namespace DemoToolkit.Mvvm.WinForms.Services;

public class WinFormsViewLocator : IViewLocatorService<Form>
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

    Form IViewLocatorService<Form>.CreateView<TViewModel>(TViewModel viewModel)
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

    void IViewLocatorService<Form>.Register<TViewModel>(Func<Form> viewFactory)
    {
        Type viewModelType = typeof(TViewModel);

        if (viewFactories.ContainsKey(viewModelType))
        {
            throw new InvalidOperationException($"View factory already registered for ViewModel type {viewModelType.Name}.");
        }

        viewFactories.Add(viewModelType, viewFactory);
    }
}
