using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DesktopGeneric;
using CommunityToolkit.Mvvm.DesktopGeneric.ValueConverters;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using TaskTamer.DataLayer.Models;

namespace TaskTamer.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ISyncContextService _syncContextService;

    private readonly System.Threading.Timer? _timer;

    public MainViewModel(ISyncContextService syncContextService)
    {
        _timer = new System.Threading.Timer(UpdateCurrentTime, null, 0, 1000);
        _syncContextService = syncContextService;
        CurrentUser = UserViewModel.FromUser(User.GetCurrentUser());
        Projects = ProjectViewModel.GetActive();

        InitViewModel();
    }

    /// <summary>
    ///  Property, which will be bound to a StatusStrip label in the MainView, showing the current time.
    /// </summary>
    [ObservableProperty]
    private string _currentDisplayTime = default!;

    /// <summary>
    ///  Property, which will be bound to a StatusStrip label in the MainView, showing the current user's name.
    /// </summary>
    [ObservableProperty]
    [property: TypeConverter(typeof(UserToStringConverter))]
    private UserViewModel? _currentUser;

    // UserViewModel cannot be displayed directly. So, we tell the Binding engine:
    // When you need to convert a User(ViewModel) into a string, use this converter.
    private class UserToStringConverter : ValueConverter<UserViewModel>
    {
        protected override UserViewModel FromString(string value) => throw new NotImplementedException();

        protected override string ToString(UserViewModel? value)
            => $"{value?.FirstName} {value?.LastName}";
    }

    ///// <summary>
    /////  Property, which will provide the list of tasks to be displayed in the MainView.
    ///// </summary>
    [ObservableProperty]
    private ObservableCollection<TaskViewModel>? _tasks;

    [ObservableProperty]
    private ObservableCollection<ProjectViewModel>? _projects;

    /// <summary>
    ///  Property, which will reflect the currently selected task in the MainView. This is a 2-way binding property.
    /// </summary>
    [ObservableProperty]
    private TaskItem? _selectedTask;

    partial void OnSelectedTaskChanged(TaskItem? oldValue, TaskItem? newValue)
    {
        Debug.Print($"Selected Task changed from {oldValue} to {newValue}");
    }
}
