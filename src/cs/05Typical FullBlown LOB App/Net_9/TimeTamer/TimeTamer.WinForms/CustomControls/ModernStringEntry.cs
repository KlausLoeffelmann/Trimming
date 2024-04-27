namespace TaskTamer9.WinForms.CustomControls;

public class ModernStringEntry : ModernTextEntry<string>
{
    public override string FormatValue(string value) => value;

    public override bool TryParseValue(string text, out string value)
    {
        value = text;
        return true;
    }
}
