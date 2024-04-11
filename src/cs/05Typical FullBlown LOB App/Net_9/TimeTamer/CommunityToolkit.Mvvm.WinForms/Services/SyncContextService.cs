using TimeTamer.Generic.UIService;

namespace CommunityToolkit.Mvvm.WinForms;

public class SyncContextService : ISyncContextService
{
    private Func<SynchronizationContext?> _syncContextFactory;

    public SyncContextService()
    {
        _syncContextFactory = () => WindowsFormsSynchronizationContext.Current;
    }

    SynchronizationContext? ISyncContextService.GetSynchronizationContext() 
        => _syncContextFactory();
}
