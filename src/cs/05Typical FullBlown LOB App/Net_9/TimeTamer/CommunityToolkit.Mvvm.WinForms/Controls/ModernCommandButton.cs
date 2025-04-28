namespace DemoToolkit.Mvvm.WinForms.Controls;

public class ModernCommandButton : Button
{
    private readonly Brush _standardForeColor;
    private readonly Brush _highLightedForeColor;

    private Font _iconFont = default!;
    private bool _requestHighlight;

    public ModernCommandButton()
    {
        _standardForeColor = new SolidBrush(ForeColor);
        _highLightedForeColor = new SolidBrush(SystemColors.HighlightText);
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        _requestHighlight = true;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        _requestHighlight = false;
        Invalidate();
    }

    protected override void OnEnabledChanged(EventArgs e)
    {
        base.OnEnabledChanged(e);
        Invalidate();
    }

    protected override void OnFontChanged(EventArgs e)
    {
        base.OnFontChanged(e);
        _iconFont = new Font("Segoe Fluent Icons", Font.Size, FontStyle.Regular, GraphicsUnit.Point);
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs paintEventArgs)
    {
        base.OnPaint(paintEventArgs);

        Graphics graphics = paintEventArgs.Graphics;
        graphics.Clear(BackColor);

        string engageSymbol;
        Brush currentBrush;

        if (Enabled)
        {
            engageSymbol = "\uE725";
            if (_requestHighlight)
            {
                currentBrush = _highLightedForeColor;
            }
            else
            {
                currentBrush = _standardForeColor;
            }
        }
        else
        {
            engageSymbol = "\uE724";
            currentBrush = _standardForeColor;
        }

        // Measure the string to center it in the button
        SizeF stringSize = graphics.MeasureString(engageSymbol, _iconFont);

        // Calculate the position to draw the string so it is centered
        float x = (Width - stringSize.Width) / 2;
        float y = (Height - stringSize.Height) / 2;

        // Draw the icon character
        graphics.DrawString(engageSymbol, _iconFont, currentBrush, x, y);
    }
}
