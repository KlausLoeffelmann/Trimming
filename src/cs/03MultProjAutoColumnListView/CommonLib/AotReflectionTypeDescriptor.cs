using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

public abstract partial class AotReflectionTypeDescriptor<T> : ICustomTypeDescriptor
{
    AttributeCollection ICustomTypeDescriptor.GetAttributes()
    {
        return new AttributeCollection(GetAttributes());
    }

    protected abstract Attribute[] GetAttributes();

    string ICustomTypeDescriptor.GetClassName()
    {
        return GetClassName();
    }

    protected abstract string GetClassName();

    string ICustomTypeDescriptor.GetComponentName()
    {
        return GetComponentName();
    }

    protected abstract string GetComponentName();

    [RequiresUnreferencedCode("TypeConverter requires unreferenced code.")]
    TypeConverter ICustomTypeDescriptor.GetConverter()
    {
        return GetConverter();
    }

    protected abstract TypeConverter GetConverter();

    [RequiresUnreferencedCode("AttributeCollection requires unreferenced code.")]
    EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
    {
        return GetDefaultEvent();
    }

    protected abstract EventDescriptor GetDefaultEvent();

    [RequiresUnreferencedCode("AttributeCollection requires unreferenced code.")]
    PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
    {
        return GetDefaultProperty();
    }

    protected abstract PropertyDescriptor GetDefaultProperty();

    [RequiresUnreferencedCode("AttributeCollection requires unreferenced code.")]
    object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
    {
        return GetEditor(editorBaseType);
    }

    protected abstract object GetEditor(Type editorBaseType);

    EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
    {
        return new EventDescriptorCollection(GetEvents());
    }

    protected abstract EventDescriptor[] GetEvents();

    [RequiresUnreferencedCode("AttributeCollection requires unreferenced code.")]
    EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[]? attributes)
    {
        return new EventDescriptorCollection(GetEvents(attributes));
    }

    protected abstract EventDescriptor[] GetEvents(Attribute[]? attributes);

    [UnconditionalSuppressMessage("Trimming", "IL2046:RequiresUnreferencedCode",
        Justification = "The returned properties are code-generated and therefore known at compile-time.")]
    PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
    {
        return new PropertyDescriptorCollection(GetProperties());
    }

    protected abstract PropertyDescriptor[] GetProperties();

    [RequiresUnreferencedCode("AttributeCollection requires unreferenced code.")]
    PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[]? attributes)
    {
        return new PropertyDescriptorCollection(GetProperties(attributes));
    }

    protected abstract PropertyDescriptor[] GetProperties(Attribute[]? attributes);

    object? ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor? pd)
    {
        return GetPropertyOwner(pd);
    }

    protected abstract object? GetPropertyOwner(PropertyDescriptor? pd);
}
