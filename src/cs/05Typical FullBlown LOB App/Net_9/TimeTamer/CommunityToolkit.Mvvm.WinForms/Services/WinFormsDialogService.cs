using DemoToolkit.Mvvm.DesktopGeneric;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Windows.Forms;

namespace DemoToolkit.Mvvm.WinForms.Services;

internal partial class WinFormsDialogService : IMvvmDialogService
{
    private IViewLocatorService<ContainerControl> _viewLocator = default!;
    private IServiceProvider _serviceProvider;

    public WinFormsDialogService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    private IViewLocatorService<ContainerControl> ViewLocator
        => _viewLocator ??= _serviceProvider.GetRequiredService<IViewLocatorService<ContainerControl>>();

    public async Task ShowMessageAsync(string message, string title)
    {
        var page = new TaskDialogPage()
        {
            Heading = title,
            Text = message,
            Buttons = [new TaskDialogButton("OK", true)],
        };

        await TaskDialog.ShowDialogAsync(page);
    }

    public async Task<bool> ShowConfirmationAsync(string message, string title)
    {
        var page = new TaskDialogPage()
        {
            Heading = title,
            Text = message,
            Buttons = [new TaskDialogButton("OK", true)],
        };

        var result = await TaskDialog.ShowDialogAsync(page);
        return result == TaskDialogButton.Yes;
    }

    public async Task ShowWarningAsync(string message, string title)
    {
        var page = new TaskDialogPage()
        {
            Heading = title,
            Text = message,
            Buttons = [new TaskDialogButton("OK", true)],
            Icon = TaskDialogIcon.Warning
        };

        await TaskDialog.ShowDialogAsync(page);
    }

    public async Task ShowErrorAsync(string message, string title)
    {
        var page = new TaskDialogPage()
        {
            Heading = title,
            Text = message,
            Buttons = [new TaskDialogButton("OK", true)],
            Icon = TaskDialogIcon.Error
        };

        await TaskDialog.ShowDialogAsync(page);
    }

    public Task<string> RequestInputAsync(string message, string title, string defaultValue = "")
    {
        throw new NotImplementedException();
    }

    public Task<T> SelectFromAsync<T>(string message, string title, IEnumerable<T> options, T? defaultOption = default)
    {
        throw new NotImplementedException();
    }

    public async Task<TResult> ShowCustomDialogAsync<TViewModel, TResult, UIStack>(TViewModel viewModel)
        where TViewModel : class, INotifyPropertyChanged
        where TResult : IDialogResult<UIStack>
        where UIStack : struct, Enum
    {
        var view = ViewLocator.CreateView(viewModel);
        DialogResult dialogResult = DialogResult.None;

        if (view is Form form)
        {
            dialogResult = await form.ShowDialogAsync();
        }

        // TODO: Figure out a way to return the dialog result value.
        return (TResult) InternalDialogResult.FromDialogResult(dialogResult, null);
    }
}
