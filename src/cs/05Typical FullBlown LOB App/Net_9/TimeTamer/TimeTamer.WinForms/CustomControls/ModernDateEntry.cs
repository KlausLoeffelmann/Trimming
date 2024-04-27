namespace TaskTamer9.WinForms.CustomControls;

public class ModernDateEntry : ModernTextEntry<DateTime>
{
    public override string FormatValue(DateTime value) => $"{value:d}";

    public override bool TryParseValue(string text, out DateTime value)
    {
        if (DateTime.TryParse(text, out var result))
        {
            value = result;
            return true;
        }

        // We invoke the LLM:
        value = default;
        return false;
    }
}
