using System.ComponentModel;

namespace WinFormsControls.DynamicProperty;

/// <summary>
///  Represents a dynamic property descriptor for a boolean property.
/// </summary>
public class DynamicBooleanPropertyDescriptor(DynamicBooleanProperty property) 
    : PropertyDescriptor(property.Name, null)
{
    private readonly DynamicBooleanProperty _property = property;

    /// <inheritdoc/>
    public override bool CanResetValue(object component) 
        => true;

    /// <inheritdoc/>
    public override Type ComponentType 
        => _property.Value.GetType();

    /// <inheritdoc/>
    public override object GetValue(object? component) 
        => _property.Value!;

    /// <inheritdoc/>
    public override bool IsReadOnly => false;

    /// <inheritdoc/>
    public override Type PropertyType => typeof(bool);

    /// <inheritdoc/>
    public override void ResetValue(object component) { }

    /// <inheritdoc/>
    public override void SetValue(object? component, object? value) 
        => _property.Value = (bool)(value ?? false);

    /// <inheritdoc/>
    public override bool ShouldSerializeValue(object component) 
        => false;
}
