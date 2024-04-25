namespace CommunityToolkit.Mvvm.WinForms.Controls;

/// <summary>
///  Provides extension methods for the <see cref="GridInfo"/> class.
/// </summary>
public static class GridInfoExtension
{
    /// <summary>
    /// Adds a column to the grid with the specified value.
    /// </summary>
    /// <param name="gridInfo">The <see cref="GridInfo"/> instance.</param>
    /// <param name="value">The value of the column.</param>
    /// <returns>The <see cref="ColumnDefinitions"/> instance.</returns>
    public static ColumnDefinitions AddColumn(this GridInfo gridInfo, string value)
    {
        gridInfo.AddColumn(new GridLength(value));
        return gridInfo.Columns;
    }

    /// <summary>
    /// Adds a row to the grid with the specified value.
    /// </summary>
    /// <param name="gridInfo">The <see cref="GridInfo"/> instance.</param>
    /// <param name="value">The value of the row.</param>
    /// <returns>The <see cref="RowDefinitions"/> instance.</returns>
    public static RowDefinitions AddRow(this GridInfo gridInfo, string value)
    {
        gridInfo.AddRow(new GridLength(value));
        return gridInfo.Rows;
    }

    /// <summary>
    /// Adds a row to the row definitions with the specified value.
    /// </summary>
    /// <param name="rowDefinitions">The <see cref="RowDefinitions"/> instance.</param>
    /// <param name="value">The value of the row.</param>
    /// <returns>The <see cref="RowDefinitions"/> instance.</returns>
    public static RowDefinitions Add(this RowDefinitions rowDefinitions, string value)
    {
        rowDefinitions.Add(new GridLength(value));
        return rowDefinitions;
    }

    /// <summary>
    /// Adds a column to the row definitions with the specified value.
    /// </summary>
    /// <param name="rowDefinitions">The <see cref="RowDefinitions"/> instance.</param>
    /// <param name="value">The value of the column.</param>
    /// <returns>The <see cref="ColumnDefinitions"/> instance.</returns>
    public static ColumnDefinitions AddColumn(this RowDefinitions rowDefinitions, string value)
    {
        var columnDefinitions = rowDefinitions.Parent.Columns;
        columnDefinitions.Add(new GridLength(value));
        return columnDefinitions;
    }

    /// <summary>
    /// Adds a column to the column definitions with the specified value.
    /// </summary>
    /// <param name="columnDefinitions">The <see cref="ColumnDefinitions"/> instance.</param>
    /// <param name="value">The value of the column.</param>
    /// <returns>The <see cref="ColumnDefinitions"/> instance.</returns>
    public static ColumnDefinitions Add(this ColumnDefinitions columnDefinitions, string value)
    {
        columnDefinitions.Add(new GridLength(value));
        return columnDefinitions;
    }

    /// <summary>
    /// Adds a row to the column definitions with the specified value.
    /// </summary>
    /// <param name="columnDefinitions">The <see cref="ColumnDefinitions"/> instance.</param>
    /// <param name="value">The value of the row.</param>
    /// <returns>The <see cref="RowDefinitions"/> instance.</returns>
    public static RowDefinitions AddRow(this ColumnDefinitions columnDefinitions, string value)
    {
        var rowDefinitions = columnDefinitions.Parent.Rows;
        rowDefinitions.Add(new GridLength(value));
        return rowDefinitions;
    }
}
