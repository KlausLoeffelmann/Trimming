using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using TaskTamer.DataLayer.Models;

namespace TaskTamer.ViewModels;

public partial class ProjectViewModel : ObservableObject
{
    [ObservableProperty]
    private Guid _projectId;

    [ObservableProperty]
    private string _name = default!;

    [ObservableProperty]
    private string? _description;

    [ObservableProperty]
    private CategoryViewModel _category = default!;

    [ObservableProperty]
    private DateTimeOffset? _startDate;

    [ObservableProperty]
    private DateTimeOffset? _endDate;

    [ObservableProperty]
    private UserViewModel? _owner;

    [ObservableProperty]
    private string? _status;

    public static ProjectViewModel? FromProject(Project? project)
    {
        if (project is null)
        {
            return null;
        }

        return new ProjectViewModel
        {
            ProjectId = project.ProjectId,
            Name = project.Name,
            Description = project.Description,
            Category = CategoryViewModel.FromCategory(project.Category),
            Owner = UserViewModel.FromUser(project.Owner),
            StartDate = project.StartDate,
            EndDate = project.EndDate,
            Status = project.Status
        };
    }

    public static ObservableCollection<ProjectViewModel> GetActive()
    {
        var projectViewModels = Project
            .GetActiveProjects()
            .ToViewModels();

        return projectViewModels;
    }

    public override string ToString() 
        => $"{Name} ({Category})";
}
