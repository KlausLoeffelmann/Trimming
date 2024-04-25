using System.Collections.ObjectModel;

namespace CommunityToolkit.Mvvm.WinForms.Controls;

/// <summary>
///  Holds the row definitions for a grid.
/// </summary>
/// <param name="parent"></param>
public class RowDefinitions(GridInfo parent) 
    : Collection<GridLength>
{
    internal GridInfo Parent { get; } = parent;
}
