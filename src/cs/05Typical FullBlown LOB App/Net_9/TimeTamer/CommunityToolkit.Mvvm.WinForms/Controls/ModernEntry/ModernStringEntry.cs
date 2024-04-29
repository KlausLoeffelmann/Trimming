using System.ComponentModel.Design;
using System.ComponentModel;
using System.Drawing.Design;

namespace DemoToolkit.Mvvm.WinForms.Controls.ModernEntry;

public class ModernStringEntry : ModernTextEntry<string?>
{
    public override string FormatValue(string? value) => value ?? string.Empty;

    public override (bool, string?) TryParseValue(string? text, bool fromAi = false)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return (true, default);
        }

        return (MakeItIntelligent ? fromAi : true, text);
    }

    protected override bool ProvidesAiSupport => true;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Bindable(true)]
    [Browsable(true)]
    [DefaultValue(null)]
    [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
    public string? Value
    {
        get => ValueInternal;
        set => ValueInternal = value;
    }
}
