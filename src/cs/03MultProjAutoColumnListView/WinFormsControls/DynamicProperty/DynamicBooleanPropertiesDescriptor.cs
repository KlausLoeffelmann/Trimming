using System.ComponentModel;

namespace WinFormsControls.DynamicProperty;

/// <summary>
///  Represents a dynamic object descriptor that implements the <see cref="ICustomTypeDescriptor"/> interface.
/// </summary>
public class DynamicBooleanPropertiesDescriptor : ICustomTypeDescriptor
{
    private readonly List<DynamicBooleanProperty> _properties = [];

    /// <summary>
    ///  Adds a dynamic boolean property to the descriptor.
    /// </summary>
    /// <param name="property">The dynamic boolean property to add.</param>
    public void AddProperty(DynamicBooleanProperty property)
    {
        _properties.Add(property);
    }

    /// <inheritdoc/>
    public AttributeCollection GetAttributes() => TypeDescriptor.GetAttributes(this, true);

    /// <inheritdoc/>
    public string GetClassName() => null!;

    /// <inheritdoc/>
    public string GetComponentName() => null!;

    /// <inheritdoc/>
    public TypeConverter GetConverter() => TypeDescriptor.GetConverter(this, true);

    /// <inheritdoc/>
    public EventDescriptor GetDefaultEvent() => null!;

    /// <inheritdoc/>
    public PropertyDescriptor GetDefaultProperty() => null!;

    /// <inheritdoc/>
    public object? GetEditor(Type editorBaseType) => TypeDescriptor.GetEditor(this, editorBaseType, true);

    /// <inheritdoc/>
    public EventDescriptorCollection GetEvents(Attribute[]? attributes) => TypeDescriptor.GetEvents(this, attributes, true);

    /// <inheritdoc/>
    public EventDescriptorCollection GetEvents() => TypeDescriptor.GetEvents(this, true);

    /// <inheritdoc/>
    public PropertyDescriptorCollection GetProperties(Attribute[]? attributes) => GetProperties();

    /// <inheritdoc/>
    public PropertyDescriptorCollection GetProperties()
    {
        var properties = new PropertyDescriptor[_properties.Count];
        for (int i = 0; i < _properties.Count; i++)
        {
            var prop = _properties[i];
            properties[i] = new DynamicBooleanPropertyDescriptor(prop);
        }
        return new PropertyDescriptorCollection(properties);
    }

    /// <inheritdoc/>
    public object? GetPropertyOwner(PropertyDescriptor? pd) => this;
}
