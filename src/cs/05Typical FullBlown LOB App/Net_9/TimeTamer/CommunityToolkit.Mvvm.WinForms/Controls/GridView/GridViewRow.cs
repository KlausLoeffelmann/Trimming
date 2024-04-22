using System.ComponentModel;

namespace CommunityToolkit.Mvvm.WinForms.Controls;

internal class GridViewRow : DataGridViewRow
{
    internal static readonly object s_bindingContextChangedEvent = new();

    public GridViewRow()
    {
    }

    /// <summary>
    ///  Occurs when after the object has been disposed.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler? Disposed;

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (disposing)
        {
            Disposed?.Invoke(this, EventArgs.Empty);
        }
    }

    public override object Clone()
    {
        var clone = (GridViewRow)base.Clone();
        return clone;
    }
}
