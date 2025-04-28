namespace DemoToolkit.Mvvm.WinForms.Controls.ModernEntry;

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class ModernGroupBox : GroupBox
{
    private static Color DefaultModernStyleBackColor
        => SystemColors.ControlLight;

    private static Rectangle DefaultTextMargin
        => new Rectangle(10, 0, 5, 10);

    private Color _modernStyleBackColor;
    private Color? _titleColor;

    private Rectangle _textMargin = DefaultTextMargin;
    private bool _modernStyleInDarkModeOnly;

    public ModernGroupBox()
    {
        // We want the modern style only in dark mode.
        ModernStyleInDarkModeOnly = true;

        // Set the default back color to the system's light control color.
        // That means, the outer panel will be the same color as the form's background.
        _modernStyleBackColor = DefaultModernStyleBackColor;

        // Set the default title color to the parent's back color.
        // This will make the title color the same as the form's background.
        TitleColor = Parent?.BackColor ?? SystemColors.Control;
    }

    [DefaultValue(true)]
    public bool ModernStyleInDarkModeOnly
    {
        get => _modernStyleInDarkModeOnly;
        set
        {
            if (_modernStyleInDarkModeOnly == value) return;
            _modernStyleInDarkModeOnly = value;
            Invalidate();
        }
    }

    private bool UseModernStyle => Application.IsDarkModeEnabled || !ModernStyleInDarkModeOnly;

    public override Color BackColor
    {
        get => UseModernStyle ? _modernStyleBackColor : base.BackColor;
        set
        {
            if (UseModernStyle)
            {
                _modernStyleBackColor = value;
            }
            else
            {
                base.BackColor = value;
            }
        }
    }

    private bool ShouldSerializeBackColor() => UseModernStyle
        ? _modernStyleBackColor != DefaultModernStyleBackColor
        : base.BackColor != Parent?.BackColor;

    private new void ResetBackColor()
    {
        if (UseModernStyle)
        {
            base.BackColor = Parent?.BackColor ?? SystemColors.Control;
        }
        else
        {
            base.BackColor = DefaultBackColor;
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        // If the control is not in dark mode and the modern style is only for dark mode,
        // we render the base controls exactly as it was.
        if (!Application.IsDarkModeEnabled && ModernStyleInDarkModeOnly)
        {
            base.OnPaint(e);
            return;
        }

        // Clear the background
        e.Graphics.Clear(TitleColor);

        // Determine the size of the text
        var textSize = TextRenderer.MeasureText(Text, new Font(Font, FontStyle.Bold));

        // Draw the text in bold and 2 points larger than the base font
        using Font textFont = new(Font.FontFamily, Font.Size + 2, FontStyle.Bold);
        TextRenderer.DrawText(e.Graphics, Text, textFont, new Point(_textMargin.Left, _textMargin.Top), ForeColor);

        int totalPanelHeight = textSize.Height + _textMargin.Top + _textMargin.Bottom;

        // Fill a rectangle below the text to act as a visual panel
        Rectangle panelRect = new Rectangle(
            _textMargin.Left,
            totalPanelHeight,
            ClientSize.Width - _textMargin.Left - _textMargin.Right,
            ClientSize.Height - totalPanelHeight);

        using SolidBrush brush = new(BackColor);
        e.Graphics.FillRectangle(brush, panelRect);
    }

    // TitleColor is ambient to Parent's BackColor
    public Color TitleColor
    {
        get => _titleColor is null
            ? Parent?.BackColor ?? SystemColors.Control
            : _titleColor.Value;

        set
        {
            if (value == TitleColor)
            {
                return;
            }

            _titleColor = value == Parent?.BackColor
                ? null
                : value;
        }
    }

    private bool ShouldSerializeTitleColor() => _titleColor.HasValue;

    private void ResetTitleColor() => TitleColor = Parent?.BackColor ?? SystemColors.Control;

    public Rectangle TextMargin
    {
        get => _textMargin;
        set
        {
            _textMargin = value;
            Invalidate(); // Causes the control to be redrawn
        }
    }

    private bool ShouldSerializeTextMargin() => _textMargin != DefaultTextMargin;
    private void ResetTextMargin() => TextMargin = DefaultTextMargin;

    private Rectangle GetScaledTextMargin(Rectangle textMargin)
    {
        int left = GetScaledMargin(textMargin.Left);
        int top = GetScaledMargin(textMargin.Top);
        int right = GetScaledMargin(textMargin.Right);
        int bottom = GetScaledMargin(textMargin.Bottom);

        return new Rectangle(left, top, right, bottom);

        int GetScaledMargin(int margin) => (int)(margin * (float)96 / DeviceDpi);
    }
}
