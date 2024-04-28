using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace DemoToolkit.Mvvm.DesktopGeneric.ValueConverters;

public readonly struct ParsableSize(Size size) : IParsable<ParsableSize>
{
    public Size Size { get; } = size;

    public static ParsableSize Parse(string s, IFormatProvider? provider)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            throw new FormatException($"The string '{s}' is not a valid Size.");
        }

        // Get the TypeConverter for Size:
        var converter = TypeDescriptor.GetConverter(typeof(Size));

        // Try to convert the string to a Size:
        if (converter.IsValid(s))
        {
            var size = (Size)converter.ConvertFromString(s)!;
            return new ParsableSize(size);
        }
        else
        {
            throw new FormatException($"The string '{s}' is not a valid Size.");
        }
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out ParsableSize result)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            result = default;
            return false;
        }

        // Get the TypeConverter for Size:
        var converter = TypeDescriptor.GetConverter(typeof(Size));

        // Try to convert the string to a Size:
        if (converter.IsValid(s))
        {
            var size = (Size)converter.ConvertFromString(s)!;
            result = new ParsableSize(size);

            return true;
        }
        else
        {
            result = default;

            return false;
        }
    }
}
