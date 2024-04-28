using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using TaskTamer.DataLayer.Models;
using TaskTamer.DTOs;

namespace TaskTamer.ViewModels;

[TypeConverter(typeof(TaskViewModelTypeConverter))]
public partial class TaskViewModel : ObservableObject
{
    [ObservableProperty]
    private Guid _taskId;

    [ObservableProperty]
    private ProjectViewModel? _project;

    [ObservableProperty]
    private string _name = null!;

    [ObservableProperty]
    private string? _description;

    [ObservableProperty]
    private UserViewModel? owner;

    [ObservableProperty]
    private DateTimeOffset? _dueDate;

    [ObservableProperty]
    private TaskItemStatus _status;

    [ObservableProperty]
    private string? _externalReference;

    override public string ToString() => Name;

    public static TaskViewModel FromTaskItem(TaskItem taskItem)
    {
        return new TaskViewModel
        {
            TaskId = taskItem.TaskItemId,
            Name = taskItem.Name,
            Description = taskItem.Description,
            Project = ProjectViewModel.FromProject(taskItem.Project),
            Owner = UserViewModel.FromUser(taskItem.Owner),
            DueDate = taskItem.DueDate,
            Status = taskItem.Status,
            ExternalReference = taskItem.ExternalReference
        };
    }
}
