using System.ComponentModel;
using System.Reflection;

public abstract partial class CompileTimeReflectionTypeDescriptor<T>
{
    private class CompileTimeReflectionPropertyDescriptor : PropertyDescriptor
    {
        private readonly PropertyInfo _propertyInfo;

        public CompileTimeReflectionPropertyDescriptor(string name, PropertyInfo propertyInfo)
            : base(name, Array.Empty<Attribute>())
        {
            _propertyInfo = propertyInfo;
        }

        public override bool CanResetValue(object component) => false;

        public override Type ComponentType => typeof(T);

        public override object? GetValue(object? component) => _propertyInfo.GetValue(component);

        public override bool IsReadOnly => false;

        public override Type PropertyType => _propertyInfo.PropertyType;

        public override void ResetValue(object component) => throw new NotImplementedException();

        public override void SetValue(object? component, object? value) => _propertyInfo.SetValue(component, value);

        public override bool ShouldSerializeValue(object component) => false;
    }
}
