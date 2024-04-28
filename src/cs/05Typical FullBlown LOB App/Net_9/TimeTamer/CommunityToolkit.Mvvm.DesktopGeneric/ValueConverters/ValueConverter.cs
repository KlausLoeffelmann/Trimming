using System.ComponentModel;
using System.Globalization;

namespace DemoToolkit.Mvvm.DesktopGeneric.ValueConverters;

public abstract class ValueConverter : TypeConverter
{
    public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
        => destinationType == typeof(string)
            || base.CanConvertTo(context, destinationType);

    public override object? ConvertTo(
        ITypeDescriptorContext? context,
        System.Globalization.CultureInfo? culture,
        object? value,
        Type destinationType)
    {
        if (destinationType == typeof(string))
        {
            return ToString(value);
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }

    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        if (value is string stringValue)
        {
            return FromString(stringValue);
        }

        return base.ConvertFrom(context, culture, value);
    }

    protected abstract string ToString(object? value);

    protected abstract object? FromString(string value);
}
