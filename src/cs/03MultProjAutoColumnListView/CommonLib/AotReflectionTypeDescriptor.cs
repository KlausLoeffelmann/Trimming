// Ignore Spelling: Aot

using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace CommonLib;

public abstract partial class AotReflectionTypeDescriptor<T> : ICustomTypeDescriptor
{
    protected readonly ICustomTypeDescriptor BaseDescriptor;

    protected AotReflectionTypeDescriptor(ICustomTypeDescriptor baseDescriptor)
    {
        BaseDescriptor = baseDescriptor;
    }

    AttributeCollection ICustomTypeDescriptor.GetAttributes() => new(GetAttributes());

    protected virtual Attribute[] GetAttributes() => Array.Empty<Attribute>();


    string ICustomTypeDescriptor.GetClassName() => GetClassName();

    protected virtual string GetClassName() => typeof(T).Name;


    string? ICustomTypeDescriptor.GetComponentName() => GetComponentName();

    protected virtual string? GetComponentName() => null;


    [RequiresUnreferencedCode("TypeConverter requires unreferenced code.")]
    TypeConverter? ICustomTypeDescriptor.GetConverter() => GetConverter();

    protected virtual TypeConverter? GetConverter() => null;


    [RequiresUnreferencedCode("AttributeCollection requires unreferenced code.")]
    EventDescriptor? ICustomTypeDescriptor.GetDefaultEvent() => GetDefaultEvent();

    protected virtual EventDescriptor? GetDefaultEvent() => null;


    [RequiresUnreferencedCode("AttributeCollection requires unreferenced code.")]
    PropertyDescriptor? ICustomTypeDescriptor.GetDefaultProperty() => GetDefaultProperty();

    protected virtual PropertyDescriptor? GetDefaultProperty() => null;


    [RequiresUnreferencedCode("AttributeCollection requires unreferenced code.")]
    object? ICustomTypeDescriptor.GetEditor(Type editorBaseType) => GetEditor(editorBaseType);

    protected virtual object? GetEditor(Type editorBaseType) => null;


    EventDescriptorCollection ICustomTypeDescriptor.GetEvents() => new(GetEvents());

    protected virtual EventDescriptor[]? GetEvents() => null;


    [RequiresUnreferencedCode("AttributeCollection requires unreferenced code.")]
    EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[]? attributes) => new(GetEvents(attributes));

    protected virtual EventDescriptor[]? GetEvents(Attribute[]? attributes) => null;


    [UnconditionalSuppressMessage("Trimming", "IL2046:RequiresUnreferencedCode",
        Justification = "The returned properties are code-generated and therefore known at compile-time.")]
    PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties() => new(GetProperties());

    protected virtual PropertyDescriptor[]? GetProperties() => null;


    [RequiresUnreferencedCode("AttributeCollection requires unreferenced code.")]
    PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[]? attributes) => new(GetProperties(attributes));

    protected virtual PropertyDescriptor[]? GetProperties(Attribute[]? attributes) => null;


    object? ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor? pd) => GetPropertyOwner(pd);

    protected virtual object? GetPropertyOwner(PropertyDescriptor? pd) => null;
}
