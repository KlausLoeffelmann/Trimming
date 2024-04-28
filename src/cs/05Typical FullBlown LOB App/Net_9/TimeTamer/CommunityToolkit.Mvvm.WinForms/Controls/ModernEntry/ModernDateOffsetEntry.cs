using System.ComponentModel;
using TaskTamer9.WinForms.CustomControls;

namespace CommunityToolkit.Mvvm.WinForms.Controls.ModernEntry;

public class ModernDateOffsetEntry : ModernTextEntry<DateTimeOffset?>
{
    private SpinnerControl? _spinner;

    public override string FormatValue(DateTimeOffset? value) => $"{value:d}";

    public override Task<bool> TryParseValueAsync(string text, out DateTimeOffset? value)
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
    public DateTimeOffset? Value
    {
        get => ValueInternal;
        set => ValueInternal = value;
    }

    private bool ShouldSerializeValue() => Value.HasValue;
    private void ResetValue() => Value = default;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(true)]
    [DefaultValue(false)]
    public bool MakeItIntelligent { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(true)]
    [DefaultValue(null)]
    public SpinnerControl Spinner
    {
        get => _spinner;
        set
        {
            if (_spinner == value)
            {
                return;
            }

            _spinner = value;
        }
    }
}
