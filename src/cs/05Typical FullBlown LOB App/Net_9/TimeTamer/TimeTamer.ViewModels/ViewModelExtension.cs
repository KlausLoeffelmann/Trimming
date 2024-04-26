using System.Collections.ObjectModel;
using TaskTamer.DataLayer.Models;

namespace TaskTamer.ViewModels;

public static class ViewModelExtension
{
    public static ObservableCollection<ProjectViewModel> ToViewModels(this IEnumerable<Project> projects)
    {
        var projectViewModels = new ObservableCollection<ProjectViewModel>();

        foreach (var project in projects)
        {
            projectViewModels.Add(project.ToViewModel());
        }

        return projectViewModels;
    }

    public static ProjectViewModel ToViewModel(this Project project)
        => ProjectViewModel.FromProject(project)!;
}
