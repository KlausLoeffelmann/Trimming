using CommunityToolkit.Mvvm.ComponentModel;
using TaskTamer.DataLayer.Models;

namespace TaskTamer.ViewModels;

public partial class CategoryViewModel : ObservableObject
{
    [ObservableProperty]
    private Guid _categoryId;

    [ObservableProperty]
    private string _name = default!;

    [ObservableProperty]
    private string? _description = default!;

    public static CategoryViewModel FromCategory(Category category)
    {
        return new CategoryViewModel
        {
            CategoryId = category.CategoryId,
            Name = category.Name,
            Description = category.Description
        };
    }

    public override string ToString() => $"{Name}";
}
