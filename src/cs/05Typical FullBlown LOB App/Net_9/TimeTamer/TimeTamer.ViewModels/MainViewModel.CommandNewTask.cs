using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskTamer.DataLayer.Models;

namespace TaskTamer.ViewModels;

public partial class MainViewModel : ObservableObject
{
    // Relay commands can also have an "availability" condition: CanExecute.
    // We can define a method that returns a boolean, and the RelayCommand will
    // automatically call that method to determine if the command can be executed.
    // If it cannot, the control bound to the command will be disabled.
    // The method name is passed as a string to the RelayCommand Attribute.
    [RelayCommand(CanExecute = nameof(CanAddTask))]
    private void AddTask()
    {
        TaskItem.CreateNew(
            NewTaskName!, 
            NewTaskDueDate, 
            SelectedProject!.ProjectId,
            CurrentUser!.UserId);

        Tasks = GetTasksForCurrentUser(SortOrder ?? SortOrderDueDate);
    }

    // In this case, the AddTaskCommand can only be executed if the NewTaskName 
    // AND a DueDate is set.
    private bool CanAddTask()
        => !string.IsNullOrWhiteSpace(NewTaskName) && NewTaskDueDate is not null;

    [ObservableProperty]
    private string? _newTaskName;

    [ObservableProperty]
    private ProjectViewModel? _selectedProject;

    [ObservableProperty]
    private DateTimeOffset? _newTaskDueDate;

    partial void OnNewTaskNameChanged(string? oldValue, string? newValue)
        => AddTaskCommand.NotifyCanExecuteChanged();

    partial void OnNewTaskDueDateChanged(DateTimeOffset? oldValue, DateTimeOffset? newValue)
        => AddTaskCommand.NotifyCanExecuteChanged();
}
