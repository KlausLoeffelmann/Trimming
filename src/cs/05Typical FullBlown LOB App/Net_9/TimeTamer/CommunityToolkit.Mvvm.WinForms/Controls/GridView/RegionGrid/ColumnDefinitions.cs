using System.Collections.ObjectModel;

namespace CommunityToolkit.Mvvm.WinForms.Controls;

/// <summary>
///  Provides the column definitions for a grid.
/// </summary>
/// <param name="parent"></param>
public class ColumnDefinitions(GridInfo parent) 
    : Collection<GridLength>
{
    internal GridInfo Parent { get; } = parent;
}
