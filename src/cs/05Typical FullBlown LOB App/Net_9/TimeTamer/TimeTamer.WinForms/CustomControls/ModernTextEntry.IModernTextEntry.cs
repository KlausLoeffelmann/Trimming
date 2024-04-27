using System.ComponentModel;

namespace TaskTamer9.WinForms.CustomControls;

public partial class ModernTextEntry<T>
{
    public interface IModernTextEntry
    {
        event EventHandler? ValueChanged;

        ModernTextEntryTextBox TextBoxInternal { get; }

        string FormatValue(T value);

        bool TryParseValue(string text, out T value);

        public T Value
        {
            get
            {
                if (CachedValue.isCached)
                {
                    return CachedValue.actualValue;
                }

                if (TryParseValue(TextBoxInternal.Text, out T value))
                {
                    CachedValue = (value, true);
                }

                return CachedValue.actualValue;
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

        void OnValueChangedInternal(CancelEventArgs e);
        void OnValidatingInternal(CancelEventArgs e);
    }
}
