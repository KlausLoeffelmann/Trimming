using System.ComponentModel;

namespace CommunityToolkit.Mvvm.WinForms.Controls;

public class GridViewRow : DataGridViewRow, IBindableComponent
{
    internal static readonly object s_bindingContextChangedEvent = new();

    private ControlBindingsCollection? _dataBindings;
    private BindingContext? _bindingContext;

    /// <summary>
    ///  Occurs when after the object has been disposed.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler? Disposed;

    /// <summary>
    ///  Occurs when the binding context has changed.
    /// </summary>
    [Category("Data binding")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public event EventHandler? BindingContextChanged;

    /// <summary>
    /// Gets or sets the <see cref="BindingContext"/> for this bindable <see cref="Component"/>.
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Category("Data binding")]
    public BindingContext? BindingContext
    {
        get => _bindingContext ??= [];

        set
        {
            if (!Equals(_bindingContext, value))
            {
                _bindingContext = value;
                OnBindingContextChanged(EventArgs.Empty);
            }
        }
    }

    /// <summary>
    ///  Raises the <see cref="BindingContextChanged"/> event.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    protected virtual void OnBindingContextChanged(EventArgs e)
    {
        if (_bindingContext is not null)
        {
            for (int i = 0; i < DataBindings.Count; i++)
            {
                BindingContext.UpdateBinding(BindingContext, DataBindings[i]);
            }
        }

        BindingContextChanged?.Invoke(this, e);
    }

    /// <summary>
    /// Gets the <see cref="ControlBindingsCollection"/> for this bindable <see cref="Component"/>.
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [RefreshProperties(RefreshProperties.All)]
    [ParenthesizePropertyName(true)]
    [Category("Data binding")]
    public ControlBindingsCollection DataBindings
        => _dataBindings ??= new ControlBindingsCollection(this);

    public ISite? Site 
    {
        get => DataGridView?.Site;
        set { }
    }

    protected Object? DataContextInternal { get; set; }

    [Browsable(false)]
    [Bindable(true)]
    public virtual object? DataContext
    {
        get => (this.DataGridView as GridView)?.CurrentRowDataContext;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (disposing)
        {
            Disposed?.Invoke(this, EventArgs.Empty);
        }
    }
}
