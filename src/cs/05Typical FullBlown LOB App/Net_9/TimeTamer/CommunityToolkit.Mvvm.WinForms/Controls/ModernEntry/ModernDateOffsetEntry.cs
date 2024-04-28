using DemoToolkit.Mvvm.WinForms.AI;
using System.ComponentModel;

namespace DemoToolkit.Mvvm.WinForms.Controls.ModernEntry;

public class ModernDateOffsetEntry : ModernTextEntry<DateTimeOffset?>
{
    private SpinnerControl? _spinner;
    private SemanticKernelBaseComponent? _skComponent;

    public override string FormatValue(DateTimeOffset? value) => $"{value:d}";

    public override async Task<(bool, DateTimeOffset?)> TryParseValueAsync(string text)
    {
        if (DateTimeOffset.TryParse(text, out var result))
        {
            return (true, result);
        }

        if (MakeItIntelligent 
            && this.SemanticKernelComponent is SemanticKernelBaseComponent skComponent)
        {
            if (Spinner is { })
            {
                Spinner.IsSpinning = true;
            }

            try
            {
                var resultString = await skComponent.RequestPromptProcessingAsync(
                    typeof(DateTimeOffset).Name,
                    text);

                if (string.IsNullOrWhiteSpace(resultString) || resultString.StartsWith("**"))
                {
                    ValidationResult = resultString;
                    return (false, default);
                }
            }
            finally
            {
                if (Spinner is { })
                {
                    Spinner.IsSpinning = false;
                }
            }
        }

        if (DateTimeOffset.TryParse(text, out result))
        {
            return (true, result);
        }

        ValidationResult = "Could not parse the entry into a valid Date value.";
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

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(true)]
    [DefaultValue(false)]
    public bool MakeItIntelligent { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(true)]
    [Bindable(false)]
    [DefaultValue(null)]
    public SpinnerControl? Spinner
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

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(true)]
    [Bindable(false)]
    [DefaultValue(null)]
    public SemanticKernelBaseComponent? SemanticKernelComponent
    {
        get => _skComponent;
        set
        {
            if (_skComponent == value)
            {
                return;
            }

            _skComponent = value;
        }
    }
}
