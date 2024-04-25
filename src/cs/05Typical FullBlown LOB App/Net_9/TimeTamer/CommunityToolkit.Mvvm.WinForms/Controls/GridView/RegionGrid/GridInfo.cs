namespace CommunityToolkit.Mvvm.WinForms.Controls;

/// <summary>
///  Provides information about the layout grid of the UIBuilder.
/// </summary>
public class GridInfo
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GridInfo"/> class.
    /// </summary>
    public GridInfo()
    {
        Columns = new ColumnDefinitions(this);
        Rows = new RowDefinitions(this);
    }

    /// <summary>
    /// Gets the column definitions of the grid.
    /// </summary>
    public ColumnDefinitions Columns { get; }

    /// <summary>
    /// Gets the row definitions of the grid.
    /// </summary>
    public RowDefinitions Rows { get; }

    /// <summary>
    /// Gets the default grid information with a single column defined as "*".
    /// </summary>
    /// <returns>The default <see cref="GridInfo"/>.</returns>
    public static GridInfo Default
        => AddColumns("*");

    /// <summary>
    /// Adds columns to the grid based on the specified column definitions.
    /// </summary>
    /// <param name="columnDefinition">The column definitions.</param>
    /// <returns>The <see cref="GridInfo"/> with the added columns.</returns>
    public static GridInfo AddColumns(params string[] columnDefinition)
    {
        var gridInfo = new GridInfo();
        foreach (var column in columnDefinition)
        {
            gridInfo.AddColumn(column);
        }

        return gridInfo;
    }

    /// <summary>
    /// Adds a column with the specified grid length to the grid.
    /// </summary>
    /// <param name="gridLength">The grid length of the column.</param>
    internal void AddColumn(GridLength gridLength)
        => Columns.Add(gridLength);

    /// <summary>
    /// Adds a row with the specified grid length to the grid.
    /// </summary>
    /// <param name="gridLength">The grid length of the row.</param>
    internal void AddRow(GridLength gridLength)
        => Rows.Add(gridLength);

    public class GridInfoCell
    {
        public GridInfoCell(GridInfo gridInfo, int row, int column)
        {
            GridInfo = gridInfo;
            Row = row;
            Column = column;
        }

        public GridInfo GridInfo { get; }
        public int Row { get; }
        public int Column { get; }
        public RectangleF Bounds { get; internal set; }
    }

    public List<GridInfoCell> GridInfoCells { get; } = new List<GridInfoCell>();

    /// <summary>
    ///  Lays out grid cells based on their row and column definitions, which may be absolute, auto, or star-sized.
    /// </summary>
    /// <param name="clientRectangle">The total available space for the grid as a <see cref="SizeF"/>.</param>
    /// <remarks>
    ///  This method computes the layout for a grid by first determining the total amount of space allocated to absolute and star-sized rows and columns. 
    ///  It subtracts the absolute dimensions from the total available space to calculate how much space is left for star-sized elements.
    ///  Each star-sized row or column is allocated a portion of the remaining space proportional to its star value relative to the total star count.
    ///  The grid is populated with <see cref="GridInfoCell"/> objects, each representing a cell in the grid with specified bounds.
    ///  Note: The method assumes that the total dimensions provided include all padding and spacing required.
    /// </remarks>
    public void DoLayout(SizeF clientRectangle)
    {
        // Calculate the total number of rows and columns
        int rowCount = Rows.Count;
        int columnCount = Columns.Count;

        // Variables to hold the total star counts
        float totalStarWidth = 0;
        float totalStarHeight = 0;

        // Variables to hold the total size of absolute and auto columns/rows
        float absoluteWidth = 0;
        float absoluteHeight = 0;

        // First pass: calculate total stars and absolute sizes
        foreach (var column in Columns)
        {
            if (column.IsStar)
            {
                totalStarWidth += column.Value;
            }
            else if (column.IsAbsolute)
            {
                absoluteWidth += column.Value;
            }
        }

        foreach (var row in Rows)
        {
            if (row.IsStar)
            {
                totalStarHeight += row.Value;
            }
            else if (row.IsAbsolute)
            {
                absoluteHeight += row.Value;
            }
        }

        // Calculate the available space for star-size cells
        float availableWidth = clientRectangle.Width - absoluteWidth;
        float availableHeight = clientRectangle.Height - absoluteHeight;

        // Calculate the width and height for each star unit
        float starUnitWidth = totalStarWidth > 0 ? availableWidth / totalStarWidth : 0;
        float starUnitHeight = totalStarHeight > 0 ? availableHeight / totalStarHeight : 0;

        // Clear the existing GridInfoCells
        GridInfoCells.Clear();

        float yOffset = 0;
        // Create GridInfoCell objects for each cell in the grid

        for (int row = 0; row < rowCount; row++)
        {
            GridLength rowInfo = Rows[row];
            float rowHeight = rowInfo.IsAbsolute 
                ? rowInfo.Value 
                : (rowInfo.IsStar 
                    ? rowInfo.Value * starUnitHeight 
                    : 0); // Adjust for 'auto' if needed

            float xOffset = 0;

            for (int column = 0; column < columnCount; column++)
            {
                GridLength columnInfo = Columns[column];

                float columnWidth = columnInfo.IsAbsolute 
                    ? columnInfo.Value 
                    : (columnInfo.IsStar 
                        ? columnInfo.Value * starUnitWidth 
                        : 0); // Adjust for 'auto' if needed

                GridInfoCell cell = new GridInfoCell(this, row, column)
                {
                    Bounds = new RectangleF(xOffset, yOffset, columnWidth, rowHeight)
                };

                GridInfoCells.Add(cell);
                xOffset += columnWidth;
            }

            yOffset += rowHeight;
        }
    }
}
