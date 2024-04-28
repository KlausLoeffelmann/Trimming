using DemoToolkit.Mvvm.DesktopGeneric;

namespace DemoToolkit.Mvvm.WinForms.Services;

/// <summary>
///  Provides a service that allows the synchronization context to be registered.
/// </summary>
public class SyncContextService : ISyncContextService
{
    private bool _isAvailable;
    private SynchronizationContext? _syncContext;

    /// <summary>
    /// Registers the synchronization context.
    /// </summary>
    /// <param name="syncContext">The synchronization context to register.</param>
    internal void RegisterSyncContext(SynchronizationContext syncContext)
    {
        _syncContext = syncContext;
        _isAvailable = true;
    }

    /// <summary>
    /// Gets a value indicating whether the synchronization context is available.
    /// </summary>
    public bool IsSyncContextAvailable => _isAvailable;

    /// <summary>
    /// Gets the synchronization context.
    /// </summary>
    public SynchronizationContext? SyncContext => _syncContext;
}
