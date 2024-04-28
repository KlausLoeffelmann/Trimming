using DemoToolkit.Mvvm.WinForms.Controls;
using System.ComponentModel;

namespace DemoToolkit.Mvvm.WinForms.Controls.ModernEntry;

public partial class ModernTextEntry<T>
{
    public interface IModernTextEntry
    {
        event EventHandler? ValueChanged;

        ModernTextEntryTextBox TextBoxInternal { get; }

        string FormatValue(T value);

        Task<(bool parseSucceded, T result)> TryParseValueAsync(string text);

        public T Value
        {
            get
            {
                if (CachedValue.isCached)
                {
                    return CachedValue.actualValue;
                }

                throw new ValueNotAvailableException(
                    "Value is not available. Please use the GetValueAsync method to get the value.");
            }

            set
            {   
                TextBoxInternal.SuspendChangedEvent();
                TextBoxInternal.Text = FormatValue(value);
                CachedValue = (value, true);
                TextBoxInternal.ResumeChangedEvent();
            }
        }

        (T actualValue, bool isCached) CachedValue { get; set; }

        public async Task<T> GetValueAsync()
        {
            if (CachedValue.isCached)
            {
                return CachedValue.actualValue;
            }

            var (parseSucceeded, returnValue) = await TryParseValueAsync(TextBoxInternal.Text);

            if (parseSucceeded)
            {
                CachedValue = (returnValue, true);
                return returnValue;
            }

            // TODO: Set the ValidationError property.
            return default!;
        }

        void OnValueChangedInternal(CancelEventArgs e);

        void OnValidatingInternal(CancelEventArgs e);
    }
}
