using System.ComponentModel;

namespace CommunityToolkit.Mvvm.WinForms.Controls;

[ToolboxItem(false)] // Prevents the component from showing up in the toolbox
public abstract partial class GridViewItemTemplate : BindableComponent, INotifyPropertyChanged
{
    protected static Color LightModeItemBackgroundColor = Color.FromArgb(255, 240, 240, 240);
    protected static Color DarkModeItemBackgroundColor = Color.FromArgb(255, 32, 32, 32);

    protected static Color LightModeHighlightedBackgroundColor = Color.FromArgb(255, 220, 220, 220);
    protected static Color DarkModeHighlightedBackgroundColor = Color.FromArgb(255, 48, 48, 48);

    protected static Color LightModeSelectedBackgroundColor = Color.FromArgb(255, 200, 200, 200);
    protected static Color DarkModeSelectedBackgroundColor = Color.FromArgb(255, 64, 64, 64);

    protected static Color LightModeItemForegroundColor = Color.FromArgb(255, 32, 32, 32);
    protected static Color DarkModeItemForegroundColor = Color.FromArgb(255, 240, 240, 240);

    protected static Color LightModeHighlightFontColor= Color.DarkBlue;
    protected static Color DarkModeHighlightFontColor = Color.LightBlue;

    protected static Color LightModeStandardFontColor = Color.FromArgb(255, 32, 32, 32);
    protected static Color DarkModeStandardFontColor = Color.FromArgb(255, 240, 240, 240);

    private SolidBrush? _itemBackgroundColorBrush;
    private SolidBrush? _itemForegroundColorBrush;
    private SolidBrush? _itemHighLightedBackgroundColor;
    private SolidBrush? _itemSelectedBackgroundColor;

    /// <summary>
    /// Occurs when a property value changes.
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Initializes a new instance of the <see cref="GridViewItemTemplate"/> class.
    /// </summary>
    public GridViewItemTemplate()
    {
        Padding = new Padding(5,5,5,5);
    }

    public Padding Padding { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal protected bool IsDarkMode { get; set; }

    public Color ItemBackgroundColor => IsDarkMode ? DarkModeItemBackgroundColor : LightModeItemBackgroundColor;
    public Color ItemForegroundColor => IsDarkMode ? DarkModeItemBackgroundColor : LightModeItemBackgroundColor;

    public Color HighlightFontColor => IsDarkMode ? DarkModeHighlightFontColor : LightModeHighlightFontColor;
    public Color StandardFontColor => IsDarkMode ? DarkModeStandardFontColor : LightModeStandardFontColor;

    public Color HighlightedBackgroundColor => IsDarkMode ? DarkModeHighlightedBackgroundColor : LightModeHighlightedBackgroundColor;
    public Color SelectedBackgroundColor => IsDarkMode ? DarkModeSelectedBackgroundColor : LightModeSelectedBackgroundColor;

    public Brush ItemBackgroundColorBrush => _itemBackgroundColorBrush ??= new SolidBrush(ItemBackgroundColor);
    public Brush ItemForegroundColorBrush => _itemForegroundColorBrush ??= new SolidBrush(ItemForegroundColor);

    public Brush HighlightedBackgroundColorBrush => _itemHighLightedBackgroundColor ??= new SolidBrush(HighlightedBackgroundColor);
    public Brush SelectedBackgroundColorBrush => _itemSelectedBackgroundColor ??= new SolidBrush(SelectedBackgroundColor);

    protected internal virtual void PaintBorder(
        Graphics graphics,
        Rectangle clipBounds,
        Rectangle cellBounds,
        DataGridViewCellStyle cellStyle,
        DataGridViewAdvancedBorderStyle advancedBorderStyle)
    { }

    protected internal virtual void PaintErrorIcon(
        Graphics graphics, 
        Rectangle clipBounds, 
        Rectangle cellBounds, 
        string? errorText)
    { }

    /// <summary>
    /// Gets the preferred size of the control.
    /// </summary>
    /// <param name="restrictedSize">The proposed size for the control.</param>
    /// <returns>The preferred size of the control.</returns>
    internal protected abstract Size GetPreferredSize(Size restrictedSize);

    /// <summary>
    /// Paints the content of the control.
    /// </summary>
    /// <param name="e">A <see cref="PaintEventArgs"/> that contains the event data.</param>
    internal protected abstract void OnPaintContent(PaintEventArgs e, Rectangle clipBounds, bool isMouseOver);

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
}
