using System.ComponentModel;

namespace DemoToolkit.Mvvm.WinForms.Controls;

[ToolboxItem(false)] // Prevents the component from showing up in the toolbox
/// <summary>
/// Represents a base class for the GridView item template.
/// </summary>
public abstract partial class GridViewItemTemplate : BindableComponent, INotifyPropertyChanged
{
    private static readonly Padding DefaultPadding = new Padding(5, 5, 5, 0);
    private static readonly Padding DefaultContentPadding = new Padding(5, 10, 5, 5);

    private const int DefaultLineSpacing = 10;

    protected static Color LightModeItemBackgroundColor = Color.FromArgb(255, 240, 240, 240);
    protected static Color DarkModeItemBackgroundColor = Color.FromArgb(255, 32, 32, 32);

    protected static Color LightModeHighlightedBackgroundColor = Color.FromArgb(255, 220, 220, 220);
    protected static Color DarkModeHighlightedBackgroundColor = Color.FromArgb(255, 48, 48, 48);

    protected static Color LightModeSelectedBackgroundColor = Color.FromArgb(255, 200, 200, 200);
    protected static Color DarkModeSelectedBackgroundColor = Color.FromArgb(255, 64, 64, 64);

    protected static Color LightModeItemForegroundColor = Color.FromArgb(255, 32, 32, 32);
    protected static Color DarkModeItemForegroundColor = Color.FromArgb(255, 240, 240, 240);

    protected static Color LightModeHighlightFontColor = Color.DarkBlue;
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
    /// Gets or sets the padding for the GridView item template.
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual Padding Padding { get; set; } = DefaultPadding;

    private bool ShouldSerializePadding() => Padding != DefaultPadding;
    private void ResetPadding() => Padding = DefaultPadding;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public virtual Padding ContentPadding { get; set; } = DefaultContentPadding;
    private bool ShouldSerializeContentPadding() => ContentPadding != DefaultContentPadding;
    private void ResetContentPadding() => ContentPadding = DefaultContentPadding;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [DefaultValue(DefaultLineSpacing)]
    public virtual int LineSpacing { get; set; } = DefaultLineSpacing;

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal protected bool IsDarkMode { get; set; }

    /// <summary>
    /// Gets the background color of the GridView item.
    /// </summary>
    public Color ItemBackgroundColor => IsDarkMode ? DarkModeItemBackgroundColor : LightModeItemBackgroundColor;

    /// <summary>
    /// Gets the foreground color of the GridView item.
    /// </summary>
    public Color ItemForegroundColor => IsDarkMode ? DarkModeItemBackgroundColor : LightModeItemBackgroundColor;

    /// <summary>
    /// Gets the font color for highlighted GridView items.
    /// </summary>
    public Color HighlightFontColor => IsDarkMode ? DarkModeHighlightFontColor : LightModeHighlightFontColor;

    /// <summary>
    /// Gets the standard font color for GridView items.
    /// </summary>
    public Color StandardFontColor => IsDarkMode ? DarkModeStandardFontColor : LightModeStandardFontColor;

    /// <summary>
    /// Gets the background color for highlighted GridView items.
    /// </summary>
    public Color HighlightedBackgroundColor => IsDarkMode ? DarkModeHighlightedBackgroundColor : LightModeHighlightedBackgroundColor;

    /// <summary>
    /// Gets the background color for selected GridView items.
    /// </summary>
    public Color SelectedBackgroundColor => IsDarkMode ? DarkModeSelectedBackgroundColor : LightModeSelectedBackgroundColor;

    /// <summary>
    /// Gets the brush for the GridView item background color.
    /// </summary>
    public Brush ItemBackgroundColorBrush => _itemBackgroundColorBrush ??= new SolidBrush(ItemBackgroundColor);

    /// <summary>
    /// Gets the brush for the GridView item foreground color.
    /// </summary>
    public Brush ItemForegroundColorBrush => _itemForegroundColorBrush ??= new SolidBrush(ItemForegroundColor);

    /// <summary>
    /// Gets the brush for the highlighted GridView item background color.
    /// </summary>
    public Brush HighlightedBackgroundColorBrush => _itemHighLightedBackgroundColor ??= new SolidBrush(HighlightedBackgroundColor);

    /// <summary>
    /// Gets the brush for the selected GridView item background color.
    /// </summary>
    public Brush SelectedBackgroundColorBrush => _itemSelectedBackgroundColor ??= new SolidBrush(SelectedBackgroundColor);

    /// <summary>
    /// Paints the border of the GridView item.
    /// </summary>
    /// <param name="graphics">The <see cref="Graphics"/> object used for painting.</param>
    /// <param name="clipBounds">The bounds of the clipping area.</param>
    /// <param name="cellBounds">The bounds of the GridView cell.</param>
    /// <param name="cellStyle">The style of the GridView cell.</param>
    /// <param name="advancedBorderStyle">The advanced border style of the GridView cell.</param>
    protected internal virtual void PaintBorder(
        Graphics graphics,
        Rectangle clipBounds,
        Rectangle cellBounds,
        DataGridViewCellStyle cellStyle,
        DataGridViewAdvancedBorderStyle advancedBorderStyle)
    { }

    /// <summary>
    /// Paints the error icon of the GridView item.
    /// </summary>
    /// <param name="graphics">The <see cref="Graphics"/> object used for painting.</param>
    /// <param name="clipBounds">The bounds of the clipping area.</param>
    /// <param name="cellBounds">The bounds of the GridView cell.</param>
    /// <param name="errorText">The error text to be displayed.</param>
    protected internal virtual void PaintErrorIcon(
        Graphics graphics,
        Rectangle clipBounds,
        Rectangle cellBounds,
        string? errorText)
    { }

    /// <summary>
    /// Gets the preferred size of the GridView item template.
    /// </summary>
    /// <param name="restrictedSize">The proposed size for the control.</param>
    /// <returns>The preferred size of the GridView item template.</returns>
    internal protected abstract Size GetPreferredSize(Size restrictedSize);

    /// <summary>
    /// Paints the content of the GridView item template.
    /// </summary>
    /// <param name="e">A <see cref="PaintEventArgs"/> that contains the event data.</param>
    /// <param name="clipBounds">The bounds of the clipping area.</param>
    /// <param name="isMouseOver">Indicates whether the mouse is over the GridView item.</param>
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
