using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace WinFormsControls;

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
            if (_notifyChangedTypes is not null)
            {
                return new StandardValuesCollection(_notifyChangedTypes.Values);
            }

            _notifyChangedTypes = [];

            // Get the assemblies referenced by the executing assembly
            var referencedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            if (referencedAssemblies is null)
            {
                return new StandardValuesCollection(_notifyChangedTypes.Values);
            }

            // Load the referenced assemblies
            foreach (Assembly assembly in referencedAssemblies)
            {
                // Get the types from the referenced assembly that implement INotifyPropertyChanged
                Type[] notifyChangedTypes = assembly.GetTypes()
                    .Where(typeItem => typeof(INotifyPropertyChanged).IsAssignableFrom(typeItem))
                    .ToArray();

                // Add the types to the dictionary
                foreach (Type type in notifyChangedTypes)
                {
                    // Exclude types starting with "MS.Internal", "System." and "Microsoft."
                    if (type.FullName is string fullTypeName && fullTypeName.Length > 0 &&
                        (fullTypeName.StartsWith("MS.Internal")
                        || fullTypeName.StartsWith("System.")
                        || fullTypeName.StartsWith("Microsoft.")))
                    {
                        continue;
                    }

                    _notifyChangedTypes[type.FullName!] = type;
                }
            }

            return new StandardValuesCollection(_notifyChangedTypes.Values);
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext? context)
            => true;
    }
}
