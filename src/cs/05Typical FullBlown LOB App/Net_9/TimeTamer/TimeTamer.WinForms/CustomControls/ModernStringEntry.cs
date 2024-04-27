using System.ComponentModel.Design;
using System.ComponentModel;
using System.Drawing.Design;

namespace TaskTamer9.WinForms.CustomControls;

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
        get => base.ValueInternal;
        set => base.ValueInternal = value;
    }
}
