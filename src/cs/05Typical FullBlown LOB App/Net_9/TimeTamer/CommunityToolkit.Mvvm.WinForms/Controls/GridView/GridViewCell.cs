using System.ComponentModel;

namespace CommunityToolkit.Mvvm.WinForms.Controls;

internal class GridViewCell : DataGridViewCell
{
    private static readonly Brush CellBackgroundBrush = new SolidBrush(Color.FromArgb(255,32,32,32));

    public GridViewCell()
    {
    }

    internal GridViewItemTemplate? ItemTemplate { get; set; }

    protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
    {
        //return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        return "Test string";
    }

    protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
    {
        var value=base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
        return new Size(value.Width, 125);
    }

    public override object Clone()
    {
        var clone = (GridViewCell)base.Clone();
        clone.ItemTemplate = ItemTemplate;
        return clone;
    }

    protected override void Paint(
        Graphics graphics, 
        Rectangle clipBounds, 
        Rectangle cellBounds, 
        int rowIndex, 
        DataGridViewElementStates cellState, 
        object value, 
        object formattedValue, 
        string errorText, 
        DataGridViewCellStyle cellStyle, 
        DataGridViewAdvancedBorderStyle advancedBorderStyle, 
        DataGridViewPaintParts paintParts)
    {
        //base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);
        clipBounds.Inflate(-2, -2);
        clipBounds.Offset(2, 2);
        var temp = ItemTemplate?.BindingContext;
        graphics.FillRectangle(CellBackgroundBrush, clipBounds);
    }

    protected override void PaintBorder(Graphics graphics, Rectangle clipBounds, Rectangle bounds, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle)
    {
        clipBounds.Inflate(-3, -3);
        clipBounds.Offset(3, 3);
        graphics.FillRectangle(CellBackgroundBrush, clipBounds);    
    }

    protected override void PaintErrorIcon(Graphics graphics, Rectangle clipBounds, Rectangle cellValueBounds, string errorText)
    {
        base.PaintErrorIcon(graphics, clipBounds, cellValueBounds, errorText);
    }
}
