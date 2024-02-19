using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace AutoColumnListViewDemo.Controls;

public partial class AutoColumnListView : ListView
{
    public class AutoColumnListViewTypeConverter : TypeConverter
    {
        private Dictionary<string, Type>? _notifyChangedTypes;

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
            if (_notifyChangedTypes?.TryGetValue((string)value, out var type) ?? false)
            {
                return type;
            }

            return null;
        }

        public override StandardValuesCollection? GetStandardValues(ITypeDescriptorContext? context)
        {
            _notifyChangedTypes ??= Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(typeItem => typeof(INotifyPropertyChanged).IsAssignableFrom(typeItem))
                    .Select(item => item)
                    .ToDictionary(item => item.ToString());

            return new StandardValuesCollection(_notifyChangedTypes.Values);
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext? context)
            => true;
    }
}
