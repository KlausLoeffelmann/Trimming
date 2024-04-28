using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using TaskTamer.DataLayer.Models;

namespace TaskTamer.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [RelayCommand(CanExecute = nameof(CanAddTask))]
    private void AddTask()
    {
        TaskItem.CreateNew(
            NewTaskName!, 
            NewTaskDueDate, 
            SelectedProject!.ProjectId,
            CurrentUser!.UserId);

        Tasks = GetTasksForCurrentUser();
    }

    private bool CanAddTask()
        => !string.IsNullOrWhiteSpace(NewTaskName) && SelectedProject is not null;

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

    partial void OnSelectedProjectChanged(ProjectViewModel? oldValue, ProjectViewModel? newValue)
    {
        Debug.Print($"Selected Project: {newValue}");
    }
}
