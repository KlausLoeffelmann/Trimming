using CommonLib;
using System.ComponentModel;

namespace AutoColumnListViewDemo.DataSources;

public class CustomerTypeDescriptor : AotReflectionTypeDescriptor<Customer>
{
    public CustomerTypeDescriptor(ICustomTypeDescriptor baseDescriptor) : base(baseDescriptor) { }

    protected override Attribute[] GetAttributes()
    {
        throw new NotImplementedException();
    }

    protected override string GetClassName() => nameof(Customer);

    protected override string GetComponentName() => null!;

    protected override TypeConverter GetConverter() => new();

    protected override EventDescriptor GetDefaultEvent() => null!;

    protected override PropertyDescriptor GetDefaultProperty() => null!;

    protected override object GetEditor(Type editorBaseType) => null!;

    protected override EventDescriptor[] GetEvents()
    {
        throw new NotImplementedException();
    }

    protected override EventDescriptor[] GetEvents(Attribute[]? attributes)
    {
        throw new NotImplementedException();
    }

    // Getting the properties without actually using reflection.
    protected override PropertyDescriptor[] GetProperties()
    {
        var typeSafePropertyDescriptors = GeneratedPropertyDescriptorFactory.GeneratePropertyDescriptors();

        // For debugging purposes.
        var propertiesAsObjects = typeSafePropertyDescriptors.Cast<object>();

        // Casting to descriptors.
        var properties=propertiesAsObjects.Cast<PropertyDescriptor>();

        // Return as an array.
        return [.. properties];
    }

    protected override PropertyDescriptor[] GetProperties(Attribute[]? attributes)
    {
        throw new NotImplementedException();
    }

    protected override object? GetPropertyOwner(PropertyDescriptor? pd)
    {
        throw new NotImplementedException();
    }
}
