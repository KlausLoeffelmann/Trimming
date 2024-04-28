using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace DemoToolkit.Mvvm.DesktopGeneric.ValueConverters;

public readonly struct ParsablePoint(Point point) : IParsable<ParsablePoint>
{
    public Point Point { get; } = point;

    public static ParsablePoint Parse(string s, IFormatProvider? provider)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            throw new FormatException($"The string '{s}' is not a valid Point.");
        }

        // Get the TypeConverter for Point:
        var converter = TypeDescriptor.GetConverter(typeof(Point));

        // Try to convert the string to a Point:
        if (converter.IsValid(s))
        {
            var point = (Point)converter.ConvertFromString(s)!;
            return new ParsablePoint(point);
        }
        else
        {
            throw new FormatException($"The string '{s}' is not a valid Point.");
        }
    }

    public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out ParsablePoint result)
    {
        if (string.IsNullOrWhiteSpace(s))
        {
            result = default;
            return false;
        }

        // Get the TypeConverter for Point:
        var converter = TypeDescriptor.GetConverter(typeof(Point));

        // Try to convert the string to a Point:
        if (converter.IsValid(s))
        {
            var point = (Point)converter.ConvertFromString(s)!;
            result = new ParsablePoint(point);

            return true;
        }
        else
        {
            result = default;

            return false;
        }
    }
}
