using CommunityToolkit.Mvvm.ComponentModel;
using TaskTamer.DataLayer.Models;

namespace TaskTamer.ViewModels;

public partial class UserViewModel : ObservableObject
{
    [ObservableProperty]
    private Guid _userId;

    [ObservableProperty]
    private string? _firstName = default;

    [ObservableProperty]
    private string _lastName = default!;

    [ObservableProperty]
    private string _email = default!;

    public static UserViewModel? FromUser(User? user) 
        => user is null
            ? null
            : new UserViewModel
            {
                UserId = user.UserId,
                FirstName = user.FirstName,

                // TODO: Last name should probably not be nullable
                LastName = user.LastName!,
                Email = user.Email
            };
}
