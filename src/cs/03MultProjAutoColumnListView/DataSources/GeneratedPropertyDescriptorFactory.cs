using CommonLib;
using CommonLib.Attributes;
using DataSources.Resources;

namespace AutoColumnListViewDemo.DataSources;

public class GeneratedPropertyDescriptorFactory
{
    public static Dictionary<string, IAotReflectionPropertyGetter<object>> GeneratePropertyDescriptors()
    {
        var propertyDescriptors = new Dictionary<string, IAotReflectionPropertyGetter<object>>
        {
            {
                nameof(Customer.IdCustomer),
                (IAotReflectionPropertyGetter<object>) new AotReflectionPropertyDescriptor<Customer, Guid>(
                    nameof(Customer.IdCustomer),
                    new Attribute[] { new SRDisplayNameAttribute(nameof(SR.Customer_DisplayName_IDCustomerName), typeof(SR)) },
                    c => c.IdCustomer,
                    (c, v) => c.IdCustomer = v)
            },
            {
                nameof(Customer.CustomerNumber),
                (IAotReflectionPropertyGetter<object>) new AotReflectionPropertyDescriptor<Customer, int>(
                    nameof(Customer.CustomerNumber),
                    new Attribute[] { new SRDisplayNameAttribute(nameof(SR.Customer_DisplayName_CustomerNumber), typeof(SR)) },
                    c => c.CustomerNumber,
                    (c, v) => c.CustomerNumber = v)
            },
            {
                nameof(Customer.FirstName),
                (IAotReflectionPropertyGetter<object>) new AotReflectionPropertyDescriptor<Customer, string?>(
                    nameof(Customer.FirstName),
                    new Attribute[] { new SRDisplayNameAttribute(nameof(SR.Customer_DisplayName_FirstName), typeof(SR)) },
                    c => c.FirstName,
                    (c, v) => c.FirstName = v)
            },
            {
                nameof(Customer.LastName),
                (IAotReflectionPropertyGetter<object>) new AotReflectionPropertyDescriptor<Customer, string?>(
                    nameof(Customer.LastName),
                    new Attribute[] { new SRDisplayNameAttribute(nameof(SR.Customer_DisplayName_LastName), typeof(SR)) },
                    c => c.LastName,
                    (c, v) => c.LastName = v)
            },
            {
                nameof(Customer.Email),
                (IAotReflectionPropertyGetter<object>) new AotReflectionPropertyDescriptor<Customer, string?>(
                    nameof(Customer.Email),
                    new Attribute[] { new SRDisplayNameAttribute(nameof(SR.Customer_DisplayName_Email), typeof(SR)) },
                    c => c.Email,
                    (c, v) => c.Email = v)
            },
            {
                nameof(Customer.AddressLine1),
                (IAotReflectionPropertyGetter<object>) new AotReflectionPropertyDescriptor<Customer, string?>(
                    nameof(Customer.AddressLine1),
                    new Attribute[] { new SRDisplayNameAttribute(nameof(SR.Customer_DisplayName_AddressLine1), typeof(SR)) },
                    c => c.AddressLine1,
                    (c, v) => c.AddressLine1 = v)
            },
            {
                nameof(Customer.AddressLine2),
                (IAotReflectionPropertyGetter<object>) new AotReflectionPropertyDescriptor<Customer, string?>(
                    nameof(Customer.AddressLine2),
                    new Attribute[] { new SRDisplayNameAttribute(nameof(SR.Customer_DisplayName_AddressLine2), typeof(SR)) },
                    c => c.AddressLine2,
                    (c, v) => c.AddressLine2 = v)
            },
            {
                nameof(Customer.City),
                (IAotReflectionPropertyGetter<object>) new AotReflectionPropertyDescriptor<Customer, string?>(
                    nameof(Customer.City),
                    new Attribute[] { new SRDisplayNameAttribute(nameof(SR.Customer_DisplayName_City), typeof(SR)) },
                    c => c.City,
                    (c, v) => c.City = v)
            },
            {
                nameof(Customer.State),
                (IAotReflectionPropertyGetter<object>) new AotReflectionPropertyDescriptor<Customer, string?>(
                    nameof(Customer.State),
                    new Attribute[] { new SRDisplayNameAttribute(nameof(SR.Customer_DisplayName_State), typeof(SR)) },
                    c => c.State,
                    (c, v) => c.State = v)
            },
            {
                nameof(Customer.PostalCode),
                (IAotReflectionPropertyGetter<object>) new AotReflectionPropertyDescriptor<Customer, string?>(
                    nameof(Customer.PostalCode),
                    new Attribute[] { new SRDisplayNameAttribute(nameof(SR.Customer_DisplayName_PostalCode), typeof(SR)) },
                    c => c.PostalCode,
                    (c, v) => c.PostalCode = v)
            }
        };

        return propertyDescriptors;
    }
}
