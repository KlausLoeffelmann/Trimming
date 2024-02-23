﻿using System.ComponentModel;

namespace CommonLib;

/// <summary>
///  Represents a compile-time reflection property descriptor.
/// </summary>
/// <typeparam name="U">The type of the property.</typeparam>
/// <param name="name">The name of the property.</param>
/// <param name="attributes">The attributes of the property.</param>
/// <param name="valueGetter">The function to get the value of the property.</param>
/// <param name="valueSetter">The action to set the value of the property.</param>
/// <param name="valueReSetter">The action to reset the value of the property.</param>
/// <param name="shouldSerializeValuePredicate">The function to determine whether the value of the property should be serialized.</param>
public class AotReflectionPropertyDescriptor<T, U>(
    string name,
    Attribute[] attributes,
    Func<T, U>? valueGetter = default,
    Action<T, U?>? valueSetter = default,
    Action? valueReSetter = default,
    Func<bool>? shouldSerializeValuePredicate = default) : PropertyDescriptor(name, attributes)
{
    private readonly Func<bool> _shouldSerializeValuePredicate
        = shouldSerializeValuePredicate ?? (() => false);

    private readonly Type _propertyType = typeof(U);

    /// <summary>
    ///  Gets a value indicating whether the property can be reset.
    /// </summary>
    /// <param name="component">The component to check.</param>
    /// <returns><c>true</c> if the property can be reset; otherwise, <c>false</c>.</returns>
    public override bool CanResetValue(object component) => valueReSetter is not null;

    /// <summary>
    ///  Gets the type of the component.
    /// </summary>
    public override Type ComponentType => typeof(T);

    /// <summary>
    ///  Gets the value of the property for the specified component.
    /// </summary>
    /// <param name="component">The component to get the value from.</param>
    /// <returns>The value of the property.</returns>
    public override object? GetValue(object? component)
        => valueGetter is null
            ? null
            : valueGetter((T)component!);

    /// <summary>
    ///  Gets a value indicating whether the property is read-only.
    /// </summary>
    public override bool IsReadOnly => false;

    /// <summary>
    ///  Gets the type of the property.
    /// </summary>
    public override Type PropertyType => typeof(U);

    /// <summary>
    ///  Resets the value of the property for the specified component.
    /// </summary>
    /// <param name="component">The component to reset the value for.</param>
    public override void ResetValue(object component) => valueReSetter?.Invoke();

    /// <summary>
    ///  Sets the value of the property for the specified component.
    /// </summary>
    /// <param name="component">The component to set the value for.</param>
    /// <param name="value">The value to set.</param>
    public override void SetValue(object? component, object? value) => valueSetter?.Invoke((T)component!, (U?)value);

    /// <summary>
    ///  Determines whether the value of the property should be serialized.
    /// </summary>
    /// <param name="component">The component to check.</param>
    /// <returns><c>true</c> if the value of the property should be serialized; otherwise, <c>false</c>.</returns>
    public override bool ShouldSerializeValue(object component) => _shouldSerializeValuePredicate();

    /// <summary>
    ///  Gets the collection of attributes for the property.
    /// </summary>
    public override AttributeCollection Attributes => base.Attributes;
}

