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
    private string? _projectName;

    [ObservableProperty]
    private string _name = null!;

    [ObservableProperty]
    private string? _description;

    [ObservableProperty]
    private string? _assignedToUserName;

    [ObservableProperty]
    private DateTimeOffset? _dueDate;

    [ObservableProperty]
    private TaskItemStatus _status;

    [ObservableProperty]
    private string? _externalReference;

    public static TaskViewModel FromTaskItem(TaskItem taskItem)
    {
        return new TaskViewModel
        {
            TaskId = taskItem.TaskItemId,
            ProjectName = taskItem.Project?.Name,
            Name = taskItem.Name,
            Description = taskItem.Description,
            AssignedToUserName = $"{taskItem.Owner.FirstName} {taskItem.Owner.LastName}",
            DueDate = taskItem.DueDate,
            Status = taskItem.Status,
            ExternalReference = taskItem.ExternalReference
        };
    }
}
