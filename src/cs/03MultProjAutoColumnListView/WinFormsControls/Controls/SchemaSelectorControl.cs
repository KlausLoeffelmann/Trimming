using WinFormsControls.DynamicProperty;

namespace WinFormsControls;

public partial class SchemaSelectorControl : UserControl
{
    private Type? _schemaType;
    private DynamicBooleanPropertiesDescriptor? _descriptor;

    public SchemaSelectorControl()
    {
        InitializeComponent();
        _propertyGrid.PropertyValueChanged += PropertyGrid_PropertyValueChanged;
    }

    private void PropertyGrid_PropertyValueChanged(object? s, PropertyValueChangedEventArgs e)
    {
    }

    public Type? SchemaType
    {
        get => _schemaType;
        set
        {
            if (value == _schemaType)
            {
                return;
            }

            _schemaType = value;
            OnSchemaTypeChanged();
        }
    }

    public string[] ColumnHeaderNames
    {
        get
        {
            if (_descriptor is null)
            {
                return [];
            }

            return _descriptor
                .GetProperties()
                // This returns a PropertyDescriptorCollection which does not implement IEnumerable<T>.
                .OfType<DynamicBooleanPropertyDescriptor>()
                // P now is of type DynamicPropertyDescriptor: We're getting Property Name and Value.
                .Select(p => (p.Name, Value: (bool)p.GetValue(_descriptor)))
                // We're filtering the properties that are set to true.
                .Where(p => p.Value)
                // We're getting the property names we need for filtering.
                .Select(p => p.Name)
                .ToArray();
        }
    }

    private void OnSchemaTypeChanged()
    {
        if (_schemaType is null)
        {
            return;
        }

        var properties = _schemaType.GetProperties();

        _descriptor = new DynamicBooleanPropertiesDescriptor();
        foreach (var property in properties)
        {
            var dynamicProperty = new DynamicBooleanProperty(property.Name, true);
            _descriptor.AddProperty(dynamicProperty);
        }

        _propertyGrid.SelectedObject = _descriptor;
    }
}
