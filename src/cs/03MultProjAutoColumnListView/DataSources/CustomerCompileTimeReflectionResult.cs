using CommonLib;
using System.ComponentModel;

namespace AutoColumnListViewDemo.DataSources;

public class CustomerCompileTimeReflectionResult : AotReflectionTypeDescriptor<Customer>
{
    protected override Attribute[] GetAttributes()
    {
        throw new NotImplementedException();
    }

    protected override string GetClassName() => "Customer";

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

    protected override PropertyDescriptor[] GetProperties()
    {
        var typeSafeProperties = PropertyDescriptorGenerator.GeneratePropertyDescriptors();
        var propertiesAsObjects = typeSafeProperties.Cast<object>();
        var properties=propertiesAsObjects.Cast<PropertyDescriptor>();
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
