using System.ComponentModel;

namespace DemoToolkit.Mvvm.WinForms.Controls;

public class BindableComboBox : ComboBox
{
    public event EventHandler? BindingValueChanged;

    [Bindable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public object? SelectedBindingValue { get => SelectedIndex == -1 ? null : Items[SelectedIndex]; set => SelectedItem = value; }

    protected override void OnSelectedIndexChanged(EventArgs e)
    {
        base.OnSelectedIndexChanged(e);
        BindingValueChanged?.Invoke(this, e);
    }
}
