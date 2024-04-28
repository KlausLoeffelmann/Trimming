using System.ComponentModel;

namespace DemoToolkit.Mvvm.WinForms.Controls.ModernEntry;

public partial class ModernTextEntry<T>
{
    public class ModernTextEntryTextBox : TextBox
    {
        private IModernTextEntry _parentPanel;

        public ModernTextEntryTextBox(IModernTextEntry parentPanel)
        {
            _parentPanel = parentPanel;
            BorderStyle = BorderStyle.None;
        }

        protected override void OnValidating(CancelEventArgs e)
        { 
            _parentPanel.OnValidatingInternal(e);
        }
    }
}
