using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace DemoToolkit.Mvvm.WinForms.Controls;

public partial class GridViewItemTemplate
{
    public class GridViewItemTemplateConverter : TypeConverter
    {
        private Dictionary<string, GridViewItemTemplateWrapper>? _itemTemplateWrappers;

        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
            => destinationType == typeof(string);

        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
            => sourceType == typeof(string);

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value is null)
                {
                    return "(none)";
                }

                return value.ToString()!;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            if (_itemTemplateWrappers?.TryGetValue((string)value, out var itemTemplateWrapper) ?? false)
            {
                return itemTemplateWrapper;
            }

            return null;
        }

        public override StandardValuesCollection? GetStandardValues(ITypeDescriptorContext? context)
        {
                // No type discovery service, fall back to this assembly.
                _itemTemplateWrappers = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(typeItem => typeof(GridViewItemTemplate).IsAssignableFrom(typeItem))
                    .Select(item => new GridViewItemTemplateWrapper(item))
                    .ToDictionary(item => item.ToString());

            return new StandardValuesCollection(_itemTemplateWrappers.Values);
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext? context)
            => true;
    }
}
