using CommunityToolkit.Mvvm.DesktopGeneric;
using System.ComponentModel;

internal partial class WinFormsDialogService : IMvvmDialogService
{
    public WinFormsDialogService(IViewLocator<ScrollableControl> viewLocator)
    {
        ViewLocator = viewLocator;
    }

    public IViewLocator<ScrollableControl> ViewLocator { get; }

    public Task ShowMessageAsync(string message, string title) 
        => MessageBox.ShowAsync(message, title);

    public async Task<bool> ShowConfirmationAsync(string message, string title)
        => await MessageBox.ShowAsync(message, title, MessageBoxButtons.YesNo) == DialogResult.Yes;

    public Task ShowWarningAsync(string message, string title)
        => MessageBox.ShowAsync(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

    public Task ShowErrorAsync(string message, string title)
        => MessageBox.ShowAsync(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

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
