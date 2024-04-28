using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing.Design;

namespace DemoToolkit.Mvvm.WinForms.Controls.ModernEntry;

/// <summary>
///  Represents a base class for a modern text entry control.
/// </summary>
/// <typeparam name="T">The type of the value.</typeparam>
public abstract partial class ModernTextEntry<T> : Panel, ModernTextEntry<T>.IModernTextEntry
{
    /// <summary>
    ///  Occurs when the text, which the user initially entered, changed.
    /// </summary>
    public event EventHandler? OriginalInputTextChanged;

    /// <summary>
    ///  Occurs when the text box padding has changed.
    /// </summary>
    public event EventHandler? TextBoxPaddingChanged;

    /// <summary>
    ///  Occurs when the value has changed.
    /// </summary>
    public event EventHandler? ValueChanged;

    /// <summary>
    /// Occurs when the validation result has changed.
    /// </summary>
    public event EventHandler? ValidationResultChanged;

    private const int DefaultPenWidth = 2;
    private static readonly Padding DefaultTextBoxPadding = new(8, 4, 8, 4);

    private readonly ModernTextEntryTextBox _textBox;
    private Pen _foreColorPen;
    private Padding _textBoxPadding;
    private string? _originalInputText;
    private string? _validationResult;

    /// <summary>
    /// Initializes a new instance of the <see cref="ModernTextEntry{T}"/> class.
    /// </summary>
    public ModernTextEntry()
    {
        BorderStyle = BorderStyle.None;
        DoubleBuffered = true;
        ResizeRedraw = true;
        TabStop = false;
        TextBoxPadding = DefaultTextBoxPadding;

        SuspendLayout();

        _foreColorPen = new Pen(ForeColor, DefaultPenWidth);

        _textBox = new ModernTextEntryTextBox(this);
        _textBox.TabStop = true;

        Controls.Add((Control)_textBox);

        ResumeLayout(true);
    }

    protected override void OnEnter(EventArgs e)
    {
        base.OnEnter(e);
        _textBox.Focus();
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
    public abstract Task<bool> TryParseValueAsync(string text, out T value);

    /// <inheritdoc/>
    protected async override void OnValidating(CancelEventArgs e)
    {
        try
        {
            // We never will cancel this event, since we need to validate asynchronously.
            // So, "holding" the focus doesn't make sense. Instead, we're delaying or preventing
            // updating the value, if the validation fails, in which case, we would set the
            // ValidationResult property.
            base.OnValidating(e);

            // TODO: Introduce cancellation token, so another validation would cancel the current one.
            // TODO: Also, cancel the parsing, if the control receives a new value or another keystroke.
            if (await TryParseValueAsync(_textBox.Text, out var value))
            {
                ValueInternal = value;
                OnValueChanged();

                return;
            }
        }
        catch (Exception ex)
        {
            // TODO: Give a derived control the chance to provide a more detailed error message.
            ValidationResult = "Could not retrieve a value based on the context provided.";
            Debug.Print($"Validation failed for {Name}: {ex.Message}");
        }
    }

    protected T ValueInternal
    {
        get => ((ModernTextEntry<T>.IModernTextEntry)this).Value;
        set => ((ModernTextEntry<T>.IModernTextEntry)this).Value = value;
    }

    // We need to raise the event, so Binding works in both directions.
    protected virtual void OnValueChanged()
        => ValueChanged?.Invoke(this, EventArgs.Empty);

    // Passing this just on from the internal TextBox:
    void IModernTextEntry.OnValueChangedInternal(CancelEventArgs e)
        => OnValueChanged();

    /// <summary>
    ///  Gets or sets the original input text.
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Bindable(true)]
    [Browsable(true)]
    [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
    public string? OriginalInputText
    {
        get => _originalInputText;
        set
        {
            if (_originalInputText == value)
            {
                return;
            }

            _originalInputText = value;
            OnOriginalInputTextChanged(EventArgs.Empty);
        }
    }

    private bool ShouldSerializeOriginalInputText()
    => _originalInputText is not null;

    private void ResetOriginalInputText()
        => OriginalInputText = null;

    protected virtual void OnOriginalInputTextChanged(EventArgs e)
        => OriginalInputTextChanged?.Invoke(this, e);

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Bindable(false)]
    [Browsable(false)]
    public string? ValidationResult 
    {
        get => _validationResult;
        set
        {

            if (_validationResult == value)
            {
                return;
            }

            _validationResult = value;
            OnValidationResultChanged(EventArgs.Empty);
        }
    }

    private bool ShouldSerializeValidationResult()
        => _validationResult is not null;

    private void ResetValidationResult()
        => ValidationResult = null;

    protected virtual void OnValidationResultChanged(EventArgs e)
        => ValidationResultChanged?.Invoke(this, e);

    // Our cached value, once to was validated.
    (T actualValue, bool isCached) IModernTextEntry.CachedValue { get; set; }

    // Provide access to the internal TextBox - we're limiting this via the Interface.
    ModernTextEntryTextBox IModernTextEntry.TextBoxInternal 
        => _textBox;

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

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(true)]
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

    private bool ShouldSerializeTextBoxPadding()
        => _textBoxPadding != DefaultTextBoxPadding;

    private void ResetTextBoxPadding()
        => TextBoxPadding = DefaultTextBoxPadding;

    protected override void OnForeColorChanged(EventArgs e)
    {
        base.OnForeColorChanged(e);
        _foreColorPen = new Pen(ForeColor, 2);
    }

    /// <inheritdoc/>
    public override Size GetPreferredSize(Size proposedSize)
    {
        // We need to get the preferred size of the TextBox, but take the padding into account:
        var preferredSize = _textBox.GetPreferredSize(proposedSize);

        return new Size(
            width: Width,
            height: preferredSize.Height + TextBoxPadding.Top + TextBoxPadding.Bottom);
    }

    /// <inheritdoc/>
    protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
    {
        // Set the bounds of the TextBox to be the same as the bounds of the Panel,
        // but take the passed padding into account:

        var preferredSize = _textBox.GetPreferredSize(
            new Size(
                width - (TextBoxPadding.Left + TextBoxPadding.Right), 
                height));

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

    /// <inheritdoc/>
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

    /// <inheritdoc/>
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
