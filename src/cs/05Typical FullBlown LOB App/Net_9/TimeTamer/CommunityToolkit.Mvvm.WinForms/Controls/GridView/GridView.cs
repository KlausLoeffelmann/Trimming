using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CommunityToolkit.Mvvm.WinForms.Controls;

public partial class GridView : DataGridView
{
    public event EventHandler? GridViewItemTemplateChanged;
    public event EventHandler? SelectedItemChanged;

    private GridViewItemTemplate? _gridViewItemTemplate;
    private INotifyCollectionChanged? _observableCollection;
    private ICollection? _underlayingList;

    private readonly Color DarkModeBackgroundColor = Color.FromArgb(255, 20, 20, 20);
    private readonly Color LightModeBackgroundColor = Color.FromArgb(255, 164, 164, 164);
    private readonly Color DarkModeSelectionColor = Color.FromArgb(255, 240, 240, 240);
    private readonly Color LightModeSelectionColor = Color.FromArgb(255, 10, 10, 10);

    private object? _selectedItem;
    private Pen _selectionPen;
    private readonly Padding _selectionPadding = new(2, 2, 2, 2);

    private Color ThemedDataGridBackground 
        => IsDarkModeEnabled 
        ? DarkModeBackgroundColor 
        : LightModeBackgroundColor;

    private Color ThemedDataGridSelectionColor
            => IsDarkModeEnabled
        ? DarkModeSelectionColor
        : LightModeSelectionColor;

    public GridView()
    {
        AllowUserToAddRows = false;
        AllowUserToDeleteRows = false;
        AllowUserToOrderColumns = false;
        AllowUserToResizeColumns = false;
        AllowUserToResizeRows = false;
        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        AutoSizeRowsMode= DataGridViewAutoSizeRowsMode.AllCells;
        DoubleBuffered = true;
        SelectionMode= DataGridViewSelectionMode.FullRowSelect;
        ColumnHeadersVisible = false;
        RowHeadersVisible = false;
        VirtualMode = true;

        _selectionPen = new Pen(ThemedDataGridSelectionColor, 2);
    }

    [Bindable(false)]
    [Browsable(true)]
    [AttributeProvider(typeof(IListSource))]
    public new object? DataContext
    {
        get => base.DataContext;
        set => base.DataContext = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Bindable(true)]
    [Browsable(false)]
    public object? SelectedItem
    {
        get => _selectedItem = base.SelectedRows.Count > 0
            ? ((IList)_underlayingList!)[SelectedRows[0].Index]
            : null;

        set
        {
            if (value == _selectedItem)
            {
                return;
            }

            try
            {
                _selectedItem = value;

                if (value is null)
                {
                    ClearSelection();
                    return;
                }

                foreach (DataGridViewRow row in Rows)
                {
                    if (((IList)_underlayingList!)[row.Index] == value)
                    {
                        ClearSelection();
                        row.Selected = true;
                        FirstDisplayedScrollingRowIndex = row.Index;
                        break;
                    }
                }
            }
            finally
            {
                OnSelectedItemChanged(EventArgs.Empty);
            }
        }
    }

    protected override void OnSelectionChanged(EventArgs e)
    {
        base.OnSelectionChanged(e);
        OnSelectedItemChanged(EventArgs.Empty);
    }

    protected virtual void OnSelectedItemChanged(EventArgs e)
        => SelectedItemChanged?.Invoke(this, e);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Bindable(false)]
    [Browsable(true)]
    public GridViewItemTemplate? GridViewItemTemplate
    {
        get => _gridViewItemTemplate;
        set
        {
            if (_gridViewItemTemplate == value)
            {
                return;
            }

            _gridViewItemTemplate = value;

            if (_gridViewItemTemplate is not null)
            {
                _gridViewItemTemplate.IsDarkMode = IsDarkModeEnabled;
            }

            OnGridViewItemTemplateChanged();
        }
    }

    protected override void OnDataContextChanged(EventArgs e)
    {
        base.OnDataContextChanged(e);

        if (IsAncestorSiteInDesignMode)
        {
            return;
        }

        AutoGenerateColumns = false;

        if (DataContext is null)
        {
            _underlayingList = null;
            _observableCollection = null;
            Rows.Clear();
            RowCount = 0;

            return;
        }

        // Let's try to retrieve the Number of rows:
        if (DataContext is INotifyCollectionChanged observableCollection
            and IList list)
        {
            _observableCollection = observableCollection;
            _underlayingList = list;

            Rows.Clear();
            RowCount = list.Count;
        }
    }

    private void OnGridViewItemTemplateChanged()
        => GridViewItemTemplateChanged?.Invoke(this, EventArgs.Empty);

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        // Add custom column "DataRowObject"
        var dataRowObjectColumn = new DataGridViewColumn(new GridViewCell() { ItemTemplate = GridViewItemTemplate })
        {
            Name = "DataColumn",
            HeaderText = "DataColumn",
            SortMode = DataGridViewColumnSortMode.NotSortable,
        };

        Columns.Clear();

        // We do not want to add the column in design mode, because then the CodeDOMSerializer will add the 
        // column to the code-behind file over and over again.
        if (IsAncestorSiteInDesignMode)
        {
            return;
        }

        Columns.Add(dataRowObjectColumn);
    }

    protected override void OnRowPrePaint(DataGridViewRowPrePaintEventArgs e)
        => e.Graphics.FillRectangle(
            new SolidBrush(ThemedDataGridBackground), 
            e.RowBounds);

    protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
    {
        if (e.RowIndex == -1)
            return;

        // Get the row
        var currentRow = Rows[e.RowIndex];

        if (currentRow.Selected)
        {
            // We're drawing a rounded rectangle around the selected row.
            var rowBounds = new Rectangle(
                    e.RowBounds.Left, 
                    e.RowBounds.Top, 
                    e.RowBounds.Width - 1, 
                    e.RowBounds.Height - 1)
                .Pad(_selectionPadding);

            e.Graphics.DrawRoundedRectangle(_selectionPen, rowBounds, new(10, 10));
        }
    }

    protected override void OnCellValueNeeded(DataGridViewCellValueEventArgs e)
    {
        base.OnCellValueNeeded(e);
        if (_underlayingList is IList list)
        {
            e.Value = list[e.RowIndex];
        }
        else
        {
            throw new InvalidOperationException("The collection must implement IList.");
        }
    }
}
