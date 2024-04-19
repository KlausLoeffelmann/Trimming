using System.Diagnostics;
using System.Windows.Forms;

namespace CommunityToolkit.Mvvm.WinForms.Controls;

public class GridView : DataGridView
{
    public event EventHandler? CurrentRowDataContextChanged;

    public GridView()
    {
        DoubleBuffered = true;
        RowTemplate = new GridViewRow();
        VirtualMode = true;
        AutoGenerateColumns = false;

        // Add custom column "DataRowObject"
        var dataRowObjectColumn = new DataGridViewTextBoxColumn
        {
            Name = "DataRowObject",
            HeaderText = "DataRowObject",
            SortMode = DataGridViewColumnSortMode.NotSortable,
            CellTemplate = new DataGridViewTextBoxCell()
        };
        Columns.Add(dataRowObjectColumn);

        // Custom draw column header
        ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
        ColumnHeadersDefaultCellStyle.Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold);
        ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
        ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

        // Custom paint rows
        RowTemplate.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
        RowTemplate.DefaultCellStyle.BackColor = Color.White;
        RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
        RowTemplate.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
        RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;

        // Custom paint cells
        CellBorderStyle = DataGridViewCellBorderStyle.None;
        DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
        DefaultCellStyle.BackColor = Color.White;
        DefaultCellStyle.ForeColor = Color.Black;
        DefaultCellStyle.SelectionBackColor = Color.LightBlue;
        DefaultCellStyle.SelectionForeColor = Color.Black;
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

    public object? CurrentRowDataContext
    {
        get
        {
            // Check if there is a current row and the data source is a BindingSource
            if (CurrentRow is not null && this.DataSource is BindingSource bindingSource)
            {
                return bindingSource.Current;
            }
            return null;
        }
    }
}
