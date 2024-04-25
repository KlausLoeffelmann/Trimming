using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskTamer.DataLayer.Models;

namespace TaskTamer.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [RelayCommand]
    private static void GenerateTestData()
    {
        var context = new TaskTamerContext();
    }
}
