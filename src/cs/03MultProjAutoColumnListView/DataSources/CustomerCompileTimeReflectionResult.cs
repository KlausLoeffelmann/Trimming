using CommonLib;
using CommonLib.Attributes;
using DataSources.Resources;
using System.ComponentModel;

namespace AutoColumnListViewDemo.DataSources;

public class CustomerCompileTimeReflectionResult : AotReflectionTypeDescriptor<Customer>
{
    private static readonly AotReflectionPropertyDescriptor<Customer, Guid> IdCustomerProperty
        = new(
            name: nameof(Customer.IdCustomer),
            attributes: [new SRDisplayNameAttribute("IdCustomer", typeof(SR))],
            valueGetter: c => c.IdCustomer,
            valueSetter: (c, v) => c.IdCustomer = v);

    private static readonly AotReflectionPropertyDescriptor<Customer, int> CustomerNumberProperty
        = new(
            name: nameof(Customer.CustomerNumber),
            attributes: [new SRDisplayNameAttribute("CustomerNumber", typeof(SR))],
            valueGetter: c => c.CustomerNumber,
            valueSetter: (c, v) => c.CustomerNumber = v);

    protected override Attribute[] GetAttributes()
    {
        throw new NotImplementedException();
    }

    protected override string GetClassName() => "Customer";

    protected override string GetComponentName() => null!;

    protected override TypeConverter GetConverter() => new TypeConverter();

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
        throw new NotImplementedException();
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
