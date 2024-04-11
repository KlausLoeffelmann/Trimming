using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TimeTamer.DataLayer.Models;

namespace TimeTamer.ViewModels;

public partial class TimeTamerMainViewModel : ObservableObject
{
    [RelayCommand]
    private static void GenerateTestData()
    {
        var context = new TimeTamerContext();
    }
}
