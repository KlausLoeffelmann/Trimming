using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

namespace CommunityToolkit.Mvvm.WinForms.Controls;

public partial class GridView : DataGridView
{
    public event EventHandler? SelectedItemChanged;

    private GridViewItemTemplate? _gridViewItemTemplate;
    private INotifyCollectionChanged? _observableCollection;
    private ICollection? _underlayingList;

    private readonly Color DarkModeBackgroundColor = Color.FromArgb(255, 20, 20, 20);
    private readonly Color LightModeBackgroundColor = Color.FromArgb(255, 164, 164, 164);
    private object? _selectedItem;

    private Color ThemedDataGridBackground 
        => IsDarkModeEnabled 
        ? DarkModeBackgroundColor 
        : LightModeBackgroundColor;

    public event EventHandler? GridViewItemTemplateChanged;

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
        ColumnHeadersVisible = false;
        RowHeadersVisible = false;
        VirtualMode = true;
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
            ? base.SelectedRows[0].DataBoundItem
            : null;

        set
        {
            if (value == _selectedItem)
            {
                return;
            }

            base.SelectedRows.Clear();
            _selectedItem = value;
            OnSelectedItemChanged(EventArgs.Empty);

            if (value is null)
            {
                return;
            }

            base.SelectedRows.Clear();

            foreach (DataGridViewRow row in Rows)
            {
                if (row.DataBoundItem == value)
                {
                    row.Selected = true;
                    break;
                }
            }
        }
    }

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
                _gridViewItemTemplate.IsDarkMode = this.IsDarkModeEnabled;
            }

            OnGridViewItemTemplateChanged();
        }
    }

    protected virtual void OnSelectedItemChanged(EventArgs e)
        => SelectedItemChanged?.Invoke(this, e);

    protected override void OnSelectionChanged(EventArgs e)
    {
        base.OnSelectionChanged(e);
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
            this.Rows.Clear();
            this.RowCount = 0;

            return;
        }

        // Let's try to retrieve the Number of rows:
        if (DataContext is INotifyCollectionChanged observableCollection
            and IList list)
        {
            _observableCollection = observableCollection;
            _underlayingList = list;

            this.Rows.Clear();

            try
            {
                this.RowCount = list.Count;
            }
            catch (Exception)
            {
                throw;
            }
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
    {
        e.Graphics.FillRectangle(new SolidBrush(ThemedDataGridBackground), e.RowBounds);
    }

    protected override void OnRowHeightInfoNeeded(DataGridViewRowHeightInfoNeededEventArgs e)
    {
        base.OnRowHeightInfoNeeded(e);
        Debug.Print($"GridView - {nameof(OnRowHeightInfoNeeded)} Row: {e.RowIndex}");
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
