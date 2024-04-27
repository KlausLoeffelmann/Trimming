using System.ComponentModel;

namespace CommunityToolkit.Mvvm.WinForms.Controls;

public class BindableComboBox : ComboBox
{
    public event EventHandler? BindingValueChanged;

    [Bindable(true)]
    public object? BindingValue
    {
        get => SelectedIndex == -1
            ? null
            : Items[SelectedIndex];

        set => SelectedItem = value;
    }

    protected override void OnSelectedIndexChanged(EventArgs e)
    {
        base.OnSelectedIndexChanged(e);
        BindingValueChanged?.Invoke(this, e);
    }
}
