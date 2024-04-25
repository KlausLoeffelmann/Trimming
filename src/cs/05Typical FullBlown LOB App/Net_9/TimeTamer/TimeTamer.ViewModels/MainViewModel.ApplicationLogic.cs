using System.Collections.ObjectModel;
using System.Globalization;
using TaskTamer.DataLayer.Models;

namespace TaskTamer.ViewModels;

public partial class MainViewModel
{
    private static string AssignCurrentDateAndTimeInCurrentCulture()
        => DateTime.Now.ToString("G", CultureInfo.CurrentCulture);

    private void InitViewModel()
    {
        EnsureSampleData();
        CurrentDisplayTime = AssignCurrentDateAndTimeInCurrentCulture();
        Tasks = GetTasksForCurrentUser();
    }

    private void UpdateCurrentTime(object? state)
    {
        if (!_syncContextService.IsSyncContextAvailable) return;

        _syncContextService
            .SyncContext!
            .Post(
                _ => CurrentDisplayTime = AssignCurrentDateAndTimeInCurrentCulture(),
                state: null);
    }

    private void EnsureSampleData()
    {
        User.EnsureSampleUsersData();

        using TaskTamerContext context = new();

        // Getting Klaus:
        var currentUser = context.Users.First(user => user.FirstName == "Klaus");

        Category.EnsureSampleCategoriesData(context);
        Project.EnsureSampleProjectsData(context, currentUser);
        TaskItem.EnsureSampleTasksData(context, currentUser);
    }

    private ObservableCollection<TaskViewModel>? GetTasksForCurrentUser()
    {
        if (CurrentUser is null) return default;

        var userTasks = TaskItem.GetTasksForUser(CurrentUser.UserId);
        var tasks = new ObservableCollection<TaskViewModel>();

        foreach (var taskItem in userTasks)
        {
            tasks.Add(TaskViewModel.FromTaskItem(taskItem));
        }

        return tasks;
    }
}
