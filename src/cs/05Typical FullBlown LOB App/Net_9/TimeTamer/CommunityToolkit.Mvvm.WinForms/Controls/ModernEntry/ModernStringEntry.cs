using System.ComponentModel.Design;
using System.ComponentModel;
using System.Drawing.Design;
using TaskTamer9.WinForms.CustomControls;

namespace CommunityToolkit.Mvvm.WinForms.Controls.ModernEntry;

public class ModernStringEntry : ModernTextEntry<string>
{
    public override string FormatValue(string value) => value;

    public override Task<bool> TryParseValueAsync(string text, out string value)
    {
        value = text;
        return Task.FromResult(true);
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Bindable(true)]
    [Browsable(true)]
    [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
    public string Value
    {
        get => ValueInternal;
        set => ValueInternal = value;
    }
}
