using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace AutoColumnListViewDemo.DataSources;

public class BindingTypeDescriptionProvider : TypeDescriptionProvider
{
    // Lookup-Table for the custom type descriptors we have learned about during binding.
    // The table is looked up by type and gets back a type descriptor factory delegate,
    // which then instantiates the actual descriptor.
    private Dictionary<Type, Func<ICustomTypeDescriptor, ICustomTypeDescriptor>> descriptorGetterLookup = new();

    private TypeDescriptionProvider _baseProvider;

    /// <summary>
    ///  Created the provider and along with it a table of known data source, 
    ///  whose descriptors have been code generated during Form-Serialization time.
    /// </summary>
    public BindingTypeDescriptionProvider(TypeDescriptionProvider baseProvider)
    {
        _baseProvider = baseProvider;
        descriptorGetterLookup.Add(typeof(Customer), (baseDescriptor) => new CustomerTypeDescriptor(baseDescriptor));
    }

    /// <summary>
    ///  Gets the dedicated custom type descriptor for a particular data source.
    /// </summary>
    /// <param name="objectType"></param>
    /// <param name="instance"></param>
    /// <returns></returns>
    public override ICustomTypeDescriptor? GetTypeDescriptor(
        [DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] 
    Type objectType, object? instance)
    {
        // Get the base descriptor:
        var baseDescriptor = _baseProvider.GetTypeDescriptor(objectType, instance);

        // Lookup the type:
        if (baseDescriptor is not null && descriptorGetterLookup.TryGetValue(objectType, out var descriptorGetter))
        {
            // Get the new descriptor form the lookup table:
            return descriptorGetter(baseDescriptor);
        }

        return baseDescriptor;
    }
}
