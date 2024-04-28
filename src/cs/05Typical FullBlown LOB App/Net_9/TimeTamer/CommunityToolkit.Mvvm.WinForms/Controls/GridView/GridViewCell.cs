using System.ComponentModel;

namespace DemoToolkit.Mvvm.WinForms.Controls;

internal class GridViewCell : DataGridViewCell
{
    private static readonly Padding s_defaultPadding = new(5, 5, 5, 0);

    private BindingSource? _bindingSource;
    private GridViewItemTemplate? _itemTemplate;
    private bool _isMouseOver;

    protected override void OnMouseEnter(int rowIndex)
    {
        base.OnMouseEnter(rowIndex);

        _isMouseOver = true;
        DataGridView?.InvalidateCell(this);
    }

    override protected void OnMouseLeave(int rowIndex)
    {
        base.OnMouseLeave(rowIndex);

        _isMouseOver = false;
        DataGridView?.InvalidateCell(this);
    }

    internal GridViewItemTemplate? ItemTemplate 
    { 
        get => _itemTemplate;

        set
        {
            if (_itemTemplate == value)
            {
                return;
            }

            _itemTemplate = value;

            // Check, if the item templates has Bindings. If not, we're done.
            // It's a miracle, where the data will then come from, but it's not our problem at this time.
            // We should have an Analyzer to point that out the users, though.
            if (_itemTemplate is null 
                || _itemTemplate.DataBindings.Count == 0)
            {
                return;
            }

            // We need to find the BindingContext of the ItemTemplate, in that
            // we need to make sure, that the Bindings are homogenous to _one_ DataSource in the template:
            for (var i = 0; i < _itemTemplate.DataBindings.Count; i++)
            {
                if (i == 0)
                {
                    _bindingSource = _itemTemplate.DataBindings[i].DataSource as BindingSource
                        ?? throw new InvalidOperationException("All Bindings in the ItemTemplate must have a BindingSource defined!");
                }
                else
                {
                    if (_bindingSource != _itemTemplate.DataBindings[i].DataSource)
                    {
                        throw new InvalidOperationException("All Bindings in the ItemTemplate must have the same BindingSource!");
                    }
                }
            }
        }
    }

    public override object Clone()
    {
        var clone = (GridViewCell)base.Clone();
        clone.ItemTemplate = ItemTemplate;
        return clone;
    }

    protected override object? GetFormattedValue(
        object? value, 
        int rowIndex, 
        ref DataGridViewCellStyle cellStyle, 
        TypeConverter? valueTypeConverter, 
        TypeConverter? formattedValueTypeConverter, 
        DataGridViewDataErrorContexts context)
    {
        return $"{(value is null ? "- - -" : value)}";
    }

    protected override Size GetPreferredSize(
        Graphics graphics, 
        DataGridViewCellStyle cellStyle, 
        int rowIndex, 
        Size constraintSize) 
        => ItemTemplate is not null
            ? ItemTemplate.GetPreferredSize(constraintSize)
            : base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);

    protected override void Paint(
        Graphics graphics, 
        Rectangle clipBounds, 
        Rectangle cellBounds, 
        int rowIndex, 
        DataGridViewElementStates cellState, 
        object? value, 
        object? formattedValue, 
        string? errorText, 
        DataGridViewCellStyle cellStyle, 
        DataGridViewAdvancedBorderStyle advancedBorderStyle, 
        DataGridViewPaintParts paintParts)
    {
        if (_bindingSource is not null)
        {
            // We need to set the DataSource of the ItemTemplate to the current row:
            _bindingSource.DataSource = value;
        }

        if (_itemTemplate is null)
        {
            return;
        }

        var padding = ItemTemplate is null
            ? s_defaultPadding
            : ItemTemplate.Padding;

        var paddedBounds=cellBounds.Pad(padding);

        ItemTemplate?.OnPaintContent(
            new PaintEventArgs(graphics, clipBounds), 
            paddedBounds, 
            _isMouseOver);
    }

    protected override void PaintErrorIcon(
        Graphics graphics, 
        Rectangle clipBounds, 
        Rectangle cellBounds, 
        string? errorText)
    {

        if (_itemTemplate is null)
        {
            base.PaintErrorIcon(graphics, clipBounds, cellBounds, errorText);
            return;
        }

        var padding = ItemTemplate is null
            ? s_defaultPadding
            : ItemTemplate.Padding;

        // Set the padding for the cell:
        cellBounds.Inflate(-padding.Right, -padding.Bottom);
        cellBounds.Offset(padding.Left, padding.Top);

        _itemTemplate.PaintErrorIcon(graphics, clipBounds, cellBounds, errorText);
    }
}
