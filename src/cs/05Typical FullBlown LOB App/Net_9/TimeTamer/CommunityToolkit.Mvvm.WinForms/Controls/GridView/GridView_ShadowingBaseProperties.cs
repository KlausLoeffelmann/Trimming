using System.ComponentModel;

namespace DemoToolkit.Mvvm.WinForms.Controls;

public partial class GridView
{
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool AllowUserToOrderColumns
    {
        get => base.AllowUserToOrderColumns;
        set => base.AllowUserToOrderColumns = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool AllowUserToResizeColumns
    {
        get => base.AllowUserToResizeColumns;
        set => base.AllowUserToResizeColumns = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool AllowUserToResizeRows
    {
        get => base.AllowUserToResizeRows;
        set => base.AllowUserToResizeRows = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataGridViewCellStyle AlternatingRowsDefaultCellStyle
    {
        get => base.AlternatingRowsDefaultCellStyle;
        set => base.AlternatingRowsDefaultCellStyle = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode
    {
        get => base.AutoSizeColumnsMode;
        set => base.AutoSizeColumnsMode = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataGridViewAutoSizeRowsMode AutoSizeRowsMode
    {
        get => base.AutoSizeRowsMode;
        set => base.AutoSizeRowsMode = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataGridViewColumnCollection Columns
    {
        get => base.Columns;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataGridViewCellStyle ColumnHeadersDefaultCellStyle
    {
        get => base.ColumnHeadersDefaultCellStyle;
        set => base.ColumnHeadersDefaultCellStyle = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new int ColumnHeadersHeight
    {
        get => base.ColumnHeadersHeight;
        set => base.ColumnHeadersHeight = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool ColumnHeadersVisible
    {
        get => base.ColumnHeadersVisible;
        set => base.ColumnHeadersVisible = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataGridViewHeaderBorderStyle ColumnHeadersBorderStyle
    {
        get => base.ColumnHeadersBorderStyle;
        set => base.ColumnHeadersBorderStyle = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataGridViewColumnHeadersHeightSizeMode ColumnHeadersHeightSizeMode
    {
        get => base.ColumnHeadersHeightSizeMode;
        set => base.ColumnHeadersHeightSizeMode = value;
    }

    [Browsable(false)]
    [Bindable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new string DataMember
    {
        get => base.DataMember;
        set => base.DataMember = value;
    }

    [Bindable(false)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new object? DataSource { get => base.DataSource; set => base.DataSource = value; }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataGridViewCellStyle DefaultCellStyle
    {
        get => base.DefaultCellStyle;
        set => base.DefaultCellStyle = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool EnableHeadersVisualStyles
    {
        get => base.EnableHeadersVisualStyles;
        set => base.EnableHeadersVisualStyles = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataGridViewHeaderBorderStyle RowHeadersBorderStyle
    {
        get => base.RowHeadersBorderStyle;
        set => base.RowHeadersBorderStyle = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataGridViewCellStyle RowsDefaultCellStyle
    {
        get => base.RowsDefaultCellStyle;
        set => base.RowsDefaultCellStyle = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataGridViewRow RowTemplate
    {
        get => base.RowTemplate;
        set => base.RowTemplate = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new int RowHeadersWidth
    {
        get => base.RowHeadersWidth;
        set => base.RowHeadersWidth = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new bool RowHeadersVisible
    {
        get => base.RowHeadersVisible;
        set => base.RowHeadersVisible = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataGridViewCellStyle RowHeadersDefaultCellStyle
    {
        get => base.RowHeadersDefaultCellStyle;
        set => base.RowHeadersDefaultCellStyle = value;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataGridViewRowHeadersWidthSizeMode RowHeadersWidthSizeMode
    {
        get => base.RowHeadersWidthSizeMode;
        set => base.RowHeadersWidthSizeMode = value;
    }
}
