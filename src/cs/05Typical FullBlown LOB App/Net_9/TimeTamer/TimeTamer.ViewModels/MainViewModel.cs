using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Globalization;
using TaskTamer.DataLayer.Models;
using TaskTamer.Generic.UIService;

namespace TaskTamer.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ISyncContextService _syncContextService;

    private readonly System.Threading.Timer? _timer;
    private readonly User _currentUser;

    public MainViewModel(ISyncContextService syncContextService)
    {
        _currentDisplayTime = AssignCurrentDateAndTimeInCurrentCulture();
        _timer = new System.Threading.Timer(UpdateCurrentTime, null, 0, 1000);
        _syncContextService = syncContextService;

        EnsureSampleData();

        _currentUser = User.GetCurrentUser();
        CurrentUserInfo = $"{_currentUser.FirstName} {_currentUser.LastName}";
        Tasks = GetTasksForCurrentUser();
    }

    private ObservableCollection<TaskViewModel>? GetTasksForCurrentUser()
    {
        var userTasks = TaskItem.GetTasksForUser(_currentUser);
        var tasks = new ObservableCollection<TaskViewModel>();
        foreach (var taskItem in userTasks)
        {
            tasks.Add(TaskViewModel.FromTaskItem(taskItem));
        }

        return tasks;
    }

    /// <summary>
    ///  Property, which will be bound to a StatusStrip label in the MainView, showing the current time.
    /// </summary>
    [ObservableProperty]
    private string _currentDisplayTime;

    ///// <summary>
    /////  Property, which will provide the list of tasks to be displayed in the MainView.
    ///// </summary>
    [ObservableProperty]
    private ObservableCollection<TaskViewModel>? _tasks;

    /// <summary>
    ///  Property, which will be bound to a StatusStrip label in the MainView, showing the current user's name.
    /// </summary>
    [ObservableProperty]
    private string? _currentUserInfo;

    /// <summary>
    ///  Property, which will reflect the currently selected task in the MainView. This is a 2-way binding property.
    /// </summary>
    [ObservableProperty]
    private TaskItem? _selectedTask;

    /// <summary>
    ///  All ObservableProperties automatically get a partial method, which can be used to react to changes in the property.
    /// </summary>
    partial void OnSelectedTaskChanged(TaskItem? oldValue, TaskItem? newValue)
    {
        SelectedTaskInfo = $"{newValue?.Name}";
    }

    [ObservableProperty]
    private string? _selectedTaskInfo;

    private static string AssignCurrentDateAndTimeInCurrentCulture()
        => DateTime.Now.ToString("G", CultureInfo.CurrentCulture);
}
