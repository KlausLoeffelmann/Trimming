using DemoToolkit.Mvvm.DesktopGeneric;

namespace DemoToolkit.Mvvm.WinForms.Services;

internal partial class WinFormsDialogService
{
    private class InternalDialogResult : IDialogResult<DialogResult>
    {
        public InternalDialogResult(DialogResult dialogResult, object? dialogReturnValue)
        {
            DialogResult = dialogResult;
            DialogReturnValue = dialogReturnValue;
        }

        public object? DialogReturnValue { get; init; }

        public DialogResult DialogResult { get; }

        public static IDialogResult<DialogResult> FromDialogResult(DialogResult dialogResult, object? returnViewModel)
            => new InternalDialogResult(dialogResult, returnViewModel);
    }
}
