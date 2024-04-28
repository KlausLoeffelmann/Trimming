using System.ComponentModel;

namespace DemoToolkit.Mvvm.DesktopGeneric.ValueConverters;

public abstract class ValueConverter<T> : TypeConverter
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
            return ToString((T?) value);
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }

    protected abstract string ToString(T? value);

    protected abstract T FromString(string value);
}
