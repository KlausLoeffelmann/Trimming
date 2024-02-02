using System.ComponentModel;
using System.Reflection;

namespace AutoColumnListViewDemo.Controls;

/// <summary>
///  Represents a custom ListView control that automatically generates columns based on the type of items in the ListView.
/// </summary>
public partial class AutoColumnListView : ListView
{
    private Type? _itemType;

    /// <summary>
    ///  Raised when the <see cref="ItemType"/> property has changed.
    /// </summary>
    public event EventHandler? ItemTypeChanged;

    /// <summary>
    ///  Initializes a new instance of the <see cref="AutoColumnListView"/> class.
    /// </summary>
    public AutoColumnListView()
    {
        View = View.Details;
        FullRowSelect = true;
        GridLines = true;
    }

    /// <summary>
    ///  Gets or sets the type of the items in the ListView.
    /// </summary>
    [TypeConverter(typeof(AutoColumnListViewTypeConverter))]
    public Type? ItemType
    {
        get => _itemType;
        set
        {
            if (_itemType == value)
            {
                return;
            }

            _itemType = value;
            BuildColumns();
            OnItemTypeChanged();
        }
    }

    /// <summary>
    ///  Raises the <see cref="ItemTypeChanged"/> event.
    /// </summary>
    protected virtual void OnItemTypeChanged()
    {
        ItemTypeChanged?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    ///  Determines whether the <see cref="ItemType"/> property should be serialized.
    /// </summary>
    /// <returns><c>true</c> if the <see cref="ItemType"/> property should be serialized; otherwise, <c>false</c>.</returns>
    private bool ShouldSerializeItemType() =>
        _itemType is not null;

    /// <summary>
    ///  Resets the <see cref="ItemType"/> property to its default value.
    /// </summary>
    private void ResetItemType() =>
        _itemType = null;

    /// <inheritdoc/>
    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        if (!IsAncestorSiteInDesignMode)
        {
            return;
        }

        if (ItemType != null)
        {
            BuildColumns();
        }
    }

    /// <summary>
    ///  Builds the columns of the ListView based on the type of items.
    /// </summary>
    private void BuildColumns()
    {
        Columns.Clear();

        if (ItemType is null)
        {
            return;
        }

        PropertyInfo[] properties = ItemType.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            // Check if we have a DisplayNameAttribute, and if yes, use it:
            var displayAttribute = property.GetCustomAttribute<SRDisplayNameAttribute>();

            if (displayAttribute is not null)
            {
                Columns.Add(displayAttribute.DisplayName);
                continue;
            }

            Columns.Add(property.Name);
        }

        AutoSizeColumnsByColumnTextWidth();
    }

    /// <summary>
    ///  Automatically resizes the columns of the ListView based on the width of the column text.
    /// </summary>
    private void AutoSizeColumnsByColumnTextWidth()
    {
        foreach (ColumnHeader column in Columns)
        {
            column.Width = -2;
        }
    }
}
