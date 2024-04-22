using CommunityToolkit.Mvvm.ComponentModel;

namespace TaskTamer.ViewModels;

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
    private DateTime? _dueDate;

    [ObservableProperty]
    private string? _status;

    [ObservableProperty]
    private string? _externalReference;
}
