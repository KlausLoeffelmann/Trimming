using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace TaskTamer.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [RelayCommand(CanExecute = nameof(CanAddTask))]
    private void AddTask()
    {
        var task = new TaskViewModel()
        {
            Name = "New Task",
            Description = "New Description",
        };
    }

    private bool CanAddTask()
        => !string.IsNullOrWhiteSpace(NewTaskName) && SelectedProject is not null;

    [ObservableProperty]
    private string _newTaskName;

    [ObservableProperty]
    private ProjectViewModel? _selectedProject;

    [ObservableProperty]
    private DateTimeOffset _newTaskDueDate;

    partial void OnNewTaskNameChanged(string? oldValue, string newValue)
        => AddTaskCommand.NotifyCanExecuteChanged();
}
