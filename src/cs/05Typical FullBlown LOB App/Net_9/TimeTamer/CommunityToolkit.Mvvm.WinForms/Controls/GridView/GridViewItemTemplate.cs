using System.ComponentModel;

namespace CommunityToolkit.Mvvm.WinForms.Controls;

[ToolboxItem(false)] // Prevents the component from showing up in the toolbox
public partial class GridViewItemTemplate : BindableComponent, INotifyPropertyChanged
{
    /// <summary>
    /// Occurs when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Initializes a new instance of the <see cref="GridViewItemTemplate"/> class.
    /// </summary>
    public GridViewItemTemplate()
    {
    }

    /// <summary>
    /// Sets the property value and raises the <see cref="PropertyChanged"/> event if the value has changed. 
    /// IMPORTANT: Don't use WithEvents fields in Visual Basic with this method!
    /// </summary>
    /// <typeparam name="T">The type of the property.</typeparam>
    /// <param name="field">The reference to the field storing the property value.</param>
    /// <param name="value">The new value to set.</param>
    /// <param name="propertyName">The name of the property. This parameter is automatically set by the compiler.</param>
    /// <returns><c>true</c> if the property value has changed; otherwise, <c>false</c>.</returns>
    public bool SetProperty<T>(ref T field, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
    {
        if (Equals(field, value))
        {
            return false;
        }

        field = value;
        OnPropertyChanged(propertyName);

        return true;
    }

    /// <summary>
    /// Raises the <see cref="PropertyChanged"/> event for the specified property.
    /// </summary>
    /// <param name="propertyName">The name of the property that has changed.</param>
    protected virtual void OnPropertyChanged(string propertyName) 
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /// <summary>
    /// Gets the preferred size of the control.
    /// </summary>
    /// <param name="proposedSize">The proposed size for the control.</param>
    /// <returns>The preferred size of the control.</returns>
    protected virtual Size GetPreferredSize(Size proposedSize) 
        => new(int.MaxValue, 200);

    /// <summary>
    /// Paints the content of the control.
    /// </summary>
    /// <param name="e">A <see cref="PaintEventArgs"/> that contains the event data.</param>
    protected virtual void OnPaintContent(PaintEventArgs e)
    {
    }
}
