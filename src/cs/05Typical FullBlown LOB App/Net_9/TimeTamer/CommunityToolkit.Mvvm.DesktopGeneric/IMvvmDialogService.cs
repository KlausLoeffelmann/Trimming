using System.ComponentModel;

namespace DemoToolkit.Mvvm.DesktopGeneric;

/// <summary>
/// Represents a service for displaying user interface dialogs and messages.
/// </summary>
/// <remarks>
/// This interface provides methods to interact with the user through various types of dialogs,
/// including simple messages, confirmations, warnings, errors, text inputs, option selections,
/// and custom dialogs. Each method is asynchronous and tailored for different types of user interactions.
/// 
/// <example>
/// Here is how you might use the <see cref="IMvvmDialogService"/> to display a simple message dialog:
/// <code>
/// public async Task ShowMessage(IUIDialogService dialogService)
/// {
///     await dialogService.ShowMessageAsync("Hello, world!", "Greeting");
/// }
/// </example>
/// 
/// <example>
/// Here is how to use the <see cref="IMvvmDialogService"/> to ask a user a yes/no question:
/// <code>
/// public async Task&lt;bool&gt; GetUserConfirmation(IUIDialogService dialogService)
/// {
///     bool result = await dialogService.ShowConfirmationAsync("Are you sure?", "Confirm");
///     return result;
/// }
/// </code>
/// </example>
/// </remarks>
public interface IMvvmDialogService
{
    /// <summary>
    /// Display a simple message to the user.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="title">The title of the message.</param>
    Task ShowMessageAsync(string message, string title);

    /// <summary>
    /// Ask the user a yes/no question.
    /// </summary>
    /// <param name="message">The question to ask.</param>
    /// <param name="title">The title of the question.</param>
    /// <returns>True if the user selects "Yes", False if the user selects "No".</returns>
    Task<bool> ShowConfirmationAsync(string message, string title);

    /// <summary>
    /// Display a warning message to the user.
    /// </summary>
    /// <param name="message">The warning message to display.</param>
    /// <param name="title">The title of the warning.</param>
    Task ShowWarningAsync(string message, string title);

    /// <summary>
    /// Display an error message to the user.
    /// </summary>
    /// <param name="message">The error message to display.</param>
    /// <param name="title">The title of the error.</param>
    Task ShowErrorAsync(string message, string title);

    /// <summary>
    /// Request simple text input from the user.
    /// </summary>
    /// <param name="message">The message requesting input.</param>
    /// <param name="title">The title of the input request.</param>
    /// <param name="defaultValue">The default value for the input.</param>
    /// <returns>The text input from the user.</returns>
    Task<string> RequestInputAsync(string message, string title, string defaultValue = "");

    /// <summary>
    /// Show a dialog to select from a list of options.
    /// </summary>
    /// <typeparam name="T">The type of the options.</typeparam>
    /// <param name="message">The message to display.</param>
    /// <param name="title">The title of the dialog.</param>
    /// <param name="options">The list of options to select from.</param>
    /// <param name="defaultOption">The default option.</param>
    /// <returns>The selected option.</returns>
    Task<T> SelectFromAsync<T>(string message, string title, IEnumerable<T> options, T? defaultOption = default);

    /// <summary>
    /// Display a custom dialog, allowing for more complex interactions and inputs.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <param name="viewModel">The view model for the custom dialog.</param>
    /// <returns>The result of the custom dialog.</returns>
    Task<TResult> ShowCustomDialogAsync<TViewModel, TResult, UIStackResult>(TViewModel viewModel)
        where TViewModel : class, INotifyPropertyChanged
        where TResult : IDialogResult<UIStackResult>
        where UIStackResult : struct, Enum;
}

public interface IDialogResult<UIStackResult>
    where UIStackResult : struct, Enum
{
    object? DialogReturnValue { get; }
    UIStackResult DialogResult { get; }
}
