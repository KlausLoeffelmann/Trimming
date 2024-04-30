using System.ComponentModel.Design;
using System.ComponentModel;
using System.Drawing.Design;

namespace DemoToolkit.Mvvm.WinForms.Controls.ModernEntry;

public class ModernStringEntry : ModernTextEntry<string?>
{
    public override string FormatValue(string? value) => value ?? string.Empty;

    public override (bool parseSucceeded, string? result) TryParseValue(
        string? text, 
        bool fromAi = false)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return (true, default);
        }

        // If we're not using AI, the text is always correct. It's a string.
        // But. If not, we assume the user input is ALWAYS incorrect, and 
        // with that, we return false, which means the AI is in charge.
        // But of course, we do this only once, so when the AI gave us the
        // result back - again, it will always be correct.
        var returnValue = (
            parseSuceeded: !MakeItIntelligent || fromAi, 
            result: text);

        ValidationResult = !returnValue.parseSuceeded 
            ? "Getting improvement suggestions!" 
            : string.Empty;

        return returnValue;
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
