using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Globalization;
using TimeTamer.Generic.UIService;

namespace TimeTamer.ViewModels;

public partial class TimeTamerMainViewModel : ObservableObject
{
    private readonly IMapper _mapper;
    private readonly ISyncContextService _syncContextService;

    private readonly System.Threading.Timer? _timer;

    [ObservableProperty]
    private string _currentDisplayTime;

    [ObservableProperty]
    private ObservableCollection<TaskViewModel>? _tasks;

    public TimeTamerMainViewModel(IMapper mapper, ISyncContextService syncContextService)
    {
        _currentDisplayTime = AssignCurrentDateAndTimeInCurrentCulture();
        _timer = new System.Threading.Timer(UpdateCurrentTime, null, 0, 1000);
        _mapper = mapper;
        _syncContextService = syncContextService;
    }

    private static string AssignCurrentDateAndTimeInCurrentCulture()
        => DateTime.Now.ToString("G", CultureInfo.CurrentCulture);
}
