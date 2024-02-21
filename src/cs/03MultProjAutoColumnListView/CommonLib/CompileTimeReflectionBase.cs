using System.ComponentModel;

namespace CommonLib;

public abstract class CompileTimeReflectionBase<T> : ICustomTypeDescriptor
{
    AttributeCollection ICustomTypeDescriptor.GetAttributes()
    {
        throw new NotImplementedException();
    }

    string ICustomTypeDescriptor.GetClassName()
    {
        throw new NotImplementedException();
    }

    string ICustomTypeDescriptor.GetComponentName()
    {
        throw new NotImplementedException();
    }

    TypeConverter ICustomTypeDescriptor.GetConverter()
    {
        throw new NotImplementedException();
    }

    EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
    {
        throw new NotImplementedException();
    }

    PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
    {
        throw new NotImplementedException();
    }

    object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
    {
        throw new NotImplementedException();
    }

    EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
    {
        throw new NotImplementedException();
    }

    EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
    {
        throw new NotImplementedException();
    }

    PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
    {
        throw new NotImplementedException();
    }

    PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
    {
        throw new NotImplementedException();
    }

    object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
    {
        throw new NotImplementedException();
    }
}
