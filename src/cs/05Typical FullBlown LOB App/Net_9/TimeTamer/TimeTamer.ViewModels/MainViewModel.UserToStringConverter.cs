using DemoToolkit.Mvvm.DesktopGeneric.ValueConverters;

namespace TaskTamer.ViewModels;

public partial class MainViewModel
{
    // UserViewModel cannot be displayed directly. So, we tell the Binding engine:
    // When you need to convert a User(ViewModel) into a string, use this converter.
    private class UserToStringConverter : ValueConverter<UserViewModel>
    {
        protected override UserViewModel FromString(string value) => throw new NotImplementedException();

        protected override string ToString(UserViewModel? value)
            => $"{value?.FirstName} {value?.LastName}";
    }
}
