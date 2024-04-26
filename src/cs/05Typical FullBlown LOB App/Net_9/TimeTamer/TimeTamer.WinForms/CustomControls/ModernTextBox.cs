using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace TaskTamer9.WinForms.CustomControls;

public partial class ModernTextBoxWrapper : Panel
{
    private const int DefaultPenWidth = 2;
    private new const int DefaultPadding = 8;

    private ModernWrapperTextBox _textBox;
    private Pen _foreColorPen;
    private bool _isDesignMode;

    public ModernTextBoxWrapper()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
        BorderStyle = BorderStyle.None;

        SuspendLayout();

        _foreColorPen = new Pen(ForeColor, DefaultPenWidth);
        Padding = new Padding(DefaultPadding);

        _textBox = new ModernWrapperTextBox(this);
        Controls.Add(_textBox);

        ResumeLayout(true);
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        base.OnHandleCreated(e);

        if (IsAncestorSiteInDesignMode || _isDesignMode)
        {
            _isDesignMode = true;
            return;
        }

        if (!IsDarkModeEnabled)
        {
            _textBox.BorderStyle = BorderStyle.Fixed3D;
        }
    }

    [Bindable(true)]
    [AllowNull]
    public override string Text
    {
        get => _textBox.Text;
        set => _textBox.Text = value;
    }

    private void TriggerOnTextChanged() 
        => OnTextChanged(EventArgs.Empty);

    public TextBox TextBox => _textBox;

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
            height: preferredSize.Height + Padding.Top + Padding.Bottom);
    }

    protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
    {
        // Set the bounds of the TextBox to be the same as the bounds of the Panel,
        // but take the passed padding into account:

        var preferredSize = _textBox.GetPreferredSize(new Size(width - (Padding.Left + Padding.Right), height));

        _textBox.SetBounds(
            x: Padding.Left,
            y: Padding.Top,
            width: width - (Padding.Left + Padding.Right),
            height: preferredSize.Height);

        base.SetBoundsCore(
            x,
            y,
            width,
            preferredSize.Height + Padding.Top + Padding.Bottom,
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
