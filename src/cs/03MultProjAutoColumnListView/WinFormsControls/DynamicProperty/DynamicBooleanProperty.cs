namespace WinFormsControls.DynamicProperty;

/// <summary>
///  Represents a dynamic boolean property with a name and value.
/// </summary>
public class DynamicBooleanProperty(string name, bool value)
{
    /// <summary>
    ///  Gets the name of the dynamic boolean property.
    /// </summary>
    public string Name { get; } = name;

    /// <summary>
    ///  Gets or sets the value of the dynamic boolean property.
    /// </summary>
    public bool Value { get; set; } = value;
}
