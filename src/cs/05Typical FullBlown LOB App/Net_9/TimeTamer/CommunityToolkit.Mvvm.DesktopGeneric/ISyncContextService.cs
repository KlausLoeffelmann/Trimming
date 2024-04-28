namespace DemoToolkit.Mvvm.DesktopGeneric;

/// <summary>
/// Represents a service for managing synchronization context.
/// </summary>
public interface ISyncContextService
{
    /// <summary>
    ///  Gets the synchronization context.
    /// </summary>
    SynchronizationContext? SyncContext { get; }

    /// <summary>
    ///  Gets a value indicating whether the synchronization context is available.
    /// </summary>
    bool IsSyncContextAvailable { get; }

    // TODO: Implement Run and RunAsync.

    /// <summary>
    ///  Posts an action to be executed on the synchronization context.
    /// </summary>
    /// <param name="action">The action to be executed.</param>
    /// <param name="state">The state object to be passed to the action.</param>
    public void Post(Action action, object? state = default)
    {
        if (IsSyncContextAvailable)
        {
            SyncContext!.Post(_ => action(), state);
        }
    }

    /// <summary>
    ///  Sends an action to be executed on the synchronization context.
    /// </summary>
    /// <param name="action">The action to be executed.</param>
    /// <param name="state">The state object to be passed to the action.</param>
    public void Send(Action action, object? state = default)
    {
        if (IsSyncContextAvailable)
        {
            SyncContext!.Send(_ => action(), state);
        }
    }
}
