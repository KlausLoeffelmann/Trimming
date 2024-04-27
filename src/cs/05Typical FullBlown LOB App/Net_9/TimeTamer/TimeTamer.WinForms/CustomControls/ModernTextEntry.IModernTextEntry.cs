﻿using System.ComponentModel;

namespace TaskTamer9.WinForms.CustomControls;

public partial class ModernTextEntry<T>
{
    public interface IModernTextEntry
    {
        event EventHandler? ValueChanged;

        ModernTextEntryTextBox TextBoxInternal { get; }

        string FormatValue(T value);

        Task<bool> TryParseValueAsync(string text, out T value);

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

            if (await TryParseValueAsync(TextBoxInternal.Text, out var value))
            {
                CachedValue = (value, true);
                return value;
            }

            // TODO: Set the ValidationError property.
            return default!;
        }

        void OnValueChangedInternal(CancelEventArgs e);
        void OnValidatingInternal(CancelEventArgs e);
    }
}
