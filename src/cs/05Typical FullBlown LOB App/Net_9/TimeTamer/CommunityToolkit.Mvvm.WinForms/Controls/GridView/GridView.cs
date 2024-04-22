using System.Diagnostics;

namespace CommunityToolkit.Mvvm.WinForms.Controls;

public partial class GridView : DataGridView
{
    public event EventHandler? CurrentRowDataContextChanged;

    public GridView()
    {
        AllowUserToAddRows = false;
        AllowUserToDeleteRows = false;
        AllowUserToOrderColumns = false;
        AllowUserToResizeColumns = false;
        AllowUserToResizeRows = false;
        AutoGenerateColumns = false;
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        AutoSizeRowsMode= DataGridViewAutoSizeRowsMode.AllCells;
        DoubleBuffered = true;
        RowHeadersVisible = false;
        RowTemplate = new GridViewRow();
        VirtualMode = true;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        // Add custom column "DataRowObject"
        var dataRowObjectColumn = new DataGridViewTextBoxColumn
        {
            Name = "CustomDataRowObject",
            HeaderText = "CustomDataRowObject",
            SortMode = DataGridViewColumnSortMode.NotSortable
        };

        Columns.Add(dataRowObjectColumn);
    }

    protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
    {
        base.OnCellPainting(e);
        Debug.Print($"GridView - {nameof(OnCellPainting)} Row: {e.RowIndex}");

        // Custom paint cells
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        {
            e.PaintBackground(e.CellBounds, true);
            e.PaintContent(e.CellBounds);
            e.Handled = true;
        }
    }

    protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
    {
        base.OnRowPrePaint(e);
        Debug.Print($"GridView - {nameof(OnRowPrePaint)} Row: {e.RowIndex}");
    }

    protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
    {
        base.OnRowPostPaint(e);
        Debug.Print($"GridView - {nameof(OnRowPostPaint)} Row: {e.RowIndex}");
    }

    protected override void OnRowHeightInfoNeeded(DataGridViewRowHeightInfoNeededEventArgs e)
    {
        base.OnRowHeightInfoNeeded(e);
        Debug.Print($"GridView - {nameof(OnRowHeightInfoNeeded)} Row: {e.RowIndex}");
    }

    private void GridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // Custom format cells
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.CellStyle is not null)
        {
            e.CellStyle.Padding = new Padding(10, 5, 10, 5);
            e.CellStyle.BackColor = Color.White;
            e.CellStyle.ForeColor = Color.Black;
            e.CellStyle.SelectionBackColor = Color.LightBlue;
            e.CellStyle.SelectionForeColor = Color.Black;
        }
    }

    protected override void OnCurrentCellChanged(EventArgs e)
    {
        base.OnCurrentCellChanged(e);
    }

    protected override void OnCellValueNeeded(DataGridViewCellValueEventArgs e)
    {
        base.OnCellValueNeeded(e);
    }

    protected override void OnCellValuePushed(DataGridViewCellValueEventArgs e)
    {
        base.OnCellValuePushed(e);
    }
}
