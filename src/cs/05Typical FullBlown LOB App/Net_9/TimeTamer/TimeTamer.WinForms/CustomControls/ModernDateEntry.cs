using System.ComponentModel;

namespace TaskTamer9.WinForms.CustomControls;

public class ModernDateEntry : ModernTextEntry<DateTime?>
{
    public override string FormatValue(DateTime? value) => $"{value:d}";

    public override Task<bool> TryParseValueAsync(string text, out DateTime? value)
    {
        if (DateTime.TryParse(text, out var result))
        {
            value = result;
            return Task.FromResult(true);
        }

        // We invoke the LLM:
        value = default;
        return Task.FromResult(false);
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Bindable(true)]
    [Browsable(true)]
    public DateTime? Value
    {
        get => base.ValueInternal;
        set => base.ValueInternal = value;
    }

    private bool ShouldSerializeValue() => Value.HasValue;

    private void ResetValue() => Value = default;
}
