using System.ComponentModel;
using System.Reflection;
using System.Xml.Linq;

namespace CommonLib;

public abstract partial class CompileTimeReflectionTypeDescriptor<T>
{
    private class CompileTimeReflectionPropertyDescriptor<U>(
        MemberDescriptor name,
        Attribute[] attributes,
        Func<T, U?>? valueGetter = default,
        Action<T, U?>? valueSetter = default,
        Action? valueReSetter = default,
        Func<bool>? shouldSerializeValuePredicate = default) : PropertyDescriptor(name, attributes)
    {
        private readonly Func<bool> _shouldSerializeValuePredicate = shouldSerializeValuePredicate ?? (() => false);
        private readonly Type _propertyType = typeof(U);

        public override bool CanResetValue(object component) => valueReSetter is not null;

        public override Type ComponentType => typeof(T);

        public override object? GetValue(object? component) => valueGetter?.Invoke((T)component!);

        public override bool IsReadOnly => false;

        public override Type PropertyType => typeof(U?);

        public override void ResetValue(object component) => valueReSetter?.Invoke();

        public override void SetValue(object? component, object? value) => valueSetter?.Invoke((T)component!, (U?)value);

        public override bool ShouldSerializeValue(object component) => false;

        public override AttributeCollection Attributes => base.Attributes;
    }
}
