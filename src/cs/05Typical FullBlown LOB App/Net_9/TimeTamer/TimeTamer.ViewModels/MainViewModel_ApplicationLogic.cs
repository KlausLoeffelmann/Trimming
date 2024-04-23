using TaskTamer.DataLayer.Models;

namespace TaskTamer.ViewModels;

public partial class MainViewModel
{
    private void UpdateCurrentTime(object? state)
    {
        if (_syncContextService.IsSyncContextAvailable)
        {
            _syncContextService.SyncContext!.Post(_ =>
            {
                CurrentDisplayTime = AssignCurrentDateAndTimeInCurrentCulture();
            }, null);
        }
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
}
