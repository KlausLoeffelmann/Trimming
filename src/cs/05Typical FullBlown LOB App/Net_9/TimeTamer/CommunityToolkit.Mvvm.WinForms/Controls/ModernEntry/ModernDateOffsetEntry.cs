using System.ComponentModel;

namespace DemoToolkit.Mvvm.WinForms.Controls.ModernEntry;

public class ModernDateOffsetEntry : ModernTextEntry<DateTimeOffset?>
{
    public override string FormatValue(DateTimeOffset? value) => $"{value:d}";

    protected override bool ProvidesAiSupport => true;

    public override (bool parseSucceeded, DateTimeOffset? result) TryParseValue(string text, bool fromAi = false)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return (true, default);
        }

        if (DateTimeOffset.TryParse(text, out var result))
        {
            return (true, result);
        }

        ValidationResult = "Could convert to a valid Date!";
        return (false, default);
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Bindable(true)]
    [Browsable(true)]
    public DateTimeOffset? Value
    {
        get => ValueInternal;
        set => ValueInternal = value;
    }

    private bool ShouldSerializeValue() => Value.HasValue;
    private void ResetValue() => Value = default;
}
