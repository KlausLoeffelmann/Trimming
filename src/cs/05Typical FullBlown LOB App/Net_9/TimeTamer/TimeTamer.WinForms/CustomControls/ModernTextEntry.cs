using System.ComponentModel;

namespace TaskTamer9.WinForms.CustomControls;

public abstract partial class ModernTextEntry<T> 
    : Panel, ModernTextEntry<T>.IModernTextEntry
{
    public event EventHandler? TextBoxPaddingChanged;
    public event EventHandler? ValueChanged;

    private const int DefaultPenWidth = 2;
    private const int DefaultTextBoxPadding = 4;

    private readonly ModernTextEntryTextBox _textBox;
    private Pen _foreColorPen;
    private Padding _textBoxPadding;

    public ModernTextEntry()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
        BorderStyle = BorderStyle.None;

        SuspendLayout();

        _foreColorPen = new Pen(ForeColor, DefaultPenWidth);
        TextBoxPadding = new Padding(DefaultTextBoxPadding);

        _textBox = new ModernTextEntryTextBox(this);
        Controls.Add((Control)_textBox);

        ResumeLayout(true);
    }

    /// <summary>
    ///  Deriving class need to implement this method to format (convert) the value to a string.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>Converted value. Preferably in a format which can be parsed back.</returns>
    public abstract string FormatValue(T value);

    /// <summary>
    ///  Deriving classes need to implement this method to parse the text into the specific value.
    /// </summary>
    /// <param name="text">The original text, which needs to be converted into the value.</param>
    /// <param name="value">The converted value.</param>
    /// <returns></returns>
    public abstract bool TryParseValue(string text, out T value);

    protected override void OnValidating(CancelEventArgs e)
        => base.OnValidating(e);

    // Our cached value, once to was validated.
    (T actualValue, bool isCached) IModernTextEntry.CachedValue { get; set; }

    // Provide access to the internal TextBox - we're limiting this via the Interface.
    ModernTextEntryTextBox IModernTextEntry.TextBoxInternal 
        => _textBox;

    // We need to raise the event, so Binding works in both directions.
    protected virtual void OnValueChanged()
        => ValueChanged?.Invoke(this, EventArgs.Empty);

    // Passing this just on from the internal TextBox:
    void IModernTextEntry.OnValueChangedInternal(CancelEventArgs e)
    => OnValueChanged();

    // Passing this just on from the internal TextBox:
    void IModernTextEntry.OnValidatingInternal(CancelEventArgs e)
        => OnValidating(e);

    protected override void CreateHandle()
    {
        base.CreateHandle();

        if (!IsDarkModeEnabled)
        {
            _textBox.BorderStyle = BorderStyle.Fixed3D;
        }
    }

    public Padding TextBoxPadding
    {
        get => _textBoxPadding;
        set
        {
            if (_textBoxPadding == value)
            {
                return;
            }

            _textBoxPadding = value;
            OnTextBoxPaddingChanged(EventArgs.Empty);
        }
    }

    protected virtual void OnTextBoxPaddingChanged(EventArgs e)
        => TextBoxPaddingChanged?.Invoke(this, e);

    protected override void OnForeColorChanged(EventArgs e)
    {
        base.OnForeColorChanged(e);
        _foreColorPen = new Pen(ForeColor, 2);
    }

    public override Size GetPreferredSize(Size proposedSize)
    {
        // We need to get the preferred size of the TextBox, but take the padding into account:
        var preferredSize = _textBox.GetPreferredSize(proposedSize);

        return new Size(
            width: Width,
            height: preferredSize.Height + TextBoxPadding.Top + TextBoxPadding.Bottom);
    }

    protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
    {
        // Set the bounds of the TextBox to be the same as the bounds of the Panel,
        // but take the passed padding into account:

        var preferredSize = _textBox.GetPreferredSize(new Size(width - (TextBoxPadding.Left + TextBoxPadding.Right), height));

        _textBox.SetBounds(
            x: TextBoxPadding.Left,
            y: TextBoxPadding.Top,
            width: width - (TextBoxPadding.Left + TextBoxPadding.Right),
            height: preferredSize.Height);

        base.SetBoundsCore(
            x,
            y,
            width,
            preferredSize.Height + TextBoxPadding.Top + TextBoxPadding.Bottom,
            specified);
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
        if (Parent is not null)
        {
            e.Graphics.FillRectangle(
                brush: new SolidBrush(Parent.BackColor),
                rect: new Rectangle(
                    x: 0,
                    y: 0,
                    width: Width,
                    height: Height));
        }

        if (!IsDarkModeEnabled)
        {
            return;
        }

        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        e.Graphics.FillRoundedRectangle(
            brush: new SolidBrush(_textBox.BackColor),
            rect: new Rectangle(
                x: 1,
                y: 1,
                width: Width - 2,
                height: Height - 2),
            radius: new(10, 10));
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        if (!IsDarkModeEnabled)
        {
            return;
        }

        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

       // Draw a border as the client rectangle:
        e.Graphics.DrawRoundedRectangle(
            pen: _foreColorPen,
            rect: new Rectangle(
                x: 1,
                y: 1,
                width: Width - 2,
                height: Height - 2),
            radius: new(10,10));
    }
}
