namespace TaskTamer9.WinForms.CustomControls;

public class ModernTextBoxWrapper : Panel
{
    private TextBox _textBox;
    private Pen _foreColorPen;

    public ModernTextBoxWrapper()
    {
        SuspendLayout();
        _textBox = new TextBox();
        _textBox.BorderStyle = BorderStyle.None;

        Padding = new Padding(8);
        Controls.Add(_textBox);
        _foreColorPen = new Pen(ForeColor, 1);
        ResumeLayout(true);
    }

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

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        e.Graphics.FillRoundedRectangle(
            brush: new SolidBrush(_textBox.BackColor),
            rect: new Rectangle(
                x: 0,
                y: 0,
                width: Width,
                height: Height),
            radius: new(10, 10));

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
