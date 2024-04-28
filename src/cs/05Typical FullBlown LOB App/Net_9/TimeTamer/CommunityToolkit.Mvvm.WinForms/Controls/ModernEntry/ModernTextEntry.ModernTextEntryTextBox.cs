using System.ComponentModel;

namespace DemoToolkit.Mvvm.WinForms.Controls.ModernEntry;

public partial class ModernTextEntry<T>
{
    public class ModernTextEntryTextBox : TextBox
    {
        private IModernTextEntry _parentPanel;
        private bool _changeEventSuspended;

        public ModernTextEntryTextBox(IModernTextEntry parentPanel)
        {
            _parentPanel = parentPanel;
            BorderStyle = BorderStyle.None;
        }

        protected override void OnValidating(CancelEventArgs e)
        { 
            if (_changeEventSuspended)
            {
                return;
            }

            _parentPanel.OnValidatingInternal(e);
        }

        internal void ResumeChangedEvent()
            => _changeEventSuspended = false;

        internal void SuspendChangedEvent()
            => _changeEventSuspended = true;
    }
}
