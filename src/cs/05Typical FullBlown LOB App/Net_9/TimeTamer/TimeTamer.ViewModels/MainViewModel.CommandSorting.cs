using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TaskTamer.ViewModels;

public partial class MainViewModel : ObservableObject
{
    // For Binding from DataSources (ViewModels) to Controls (Views),
    // we need to have properties in the DataSource, that can "tell" the
    // Control that they've changed.
    [ObservableProperty]
    private string? _sortOrder = "DueDate";

    partial void OnSortOrderChanged(string? oldValue, string? newValue)
        => Tasks = GetTasksForCurrentUser(newValue ?? SortOrderDueDate);

    // For CommandBinding, we need a property of ICommand in the ViewModel. And we need a property of
    // ICommand in the View. In the ViewModel, that property "points" to a method in the ViewModel.
    [RelayCommand()]
    private void SetSortOrder(string sortOrder)
    {
        SortOrder = sortOrder;
    }
}
