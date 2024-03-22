using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace AutoColumnListViewDemo.DataSources;

public class BindingTypeDescriptionProvider : TypeDescriptionProvider
{
    private Dictionary<Type, Type> _typeLookup = new();

    public BindingTypeDescriptionProvider()
    {
        _typeLookup.Add(typeof(Customer), typeof(CustomerCompileTimeReflectionResult));
    }

    public override ICustomTypeDescriptor? GetTypeDescriptor(
        [DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] 
    Type objectType, object? instance)
    {
        // Lookup the type:
        if (_typeLookup.TryGetValue(objectType, out var descriptorType)) 
        {
            // Instantiate that type and return instance:



        }
    }
}
