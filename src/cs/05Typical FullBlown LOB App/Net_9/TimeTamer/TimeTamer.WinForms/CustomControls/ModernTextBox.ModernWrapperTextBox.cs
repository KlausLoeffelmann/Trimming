namespace TaskTamer9.WinForms.CustomControls;

public partial class ModernTextBoxWrapper
{
    private class ModernWrapperTextBox : TextBox
    {
        private ModernTextBoxWrapper _parentPanel;

        public ModernWrapperTextBox(ModernTextBoxWrapper parentPanel)
        {
            _parentPanel = parentPanel;
            BorderStyle = BorderStyle.None;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            _parentPanel.TriggerOnTextChanged();
        }
    }
}
