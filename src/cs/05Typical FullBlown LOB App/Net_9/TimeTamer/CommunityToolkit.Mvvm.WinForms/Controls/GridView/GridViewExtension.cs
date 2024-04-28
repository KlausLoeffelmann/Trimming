namespace DemoToolkit.Mvvm.WinForms.Controls;

internal static class GridViewExtension
{
    public static Rectangle Pad(this Rectangle rec, Padding padding)
    {
        Rectangle recReturn = new(
            rec.X + padding.Left,
            rec.Y + padding.Top,
            rec.Width - padding.Left - padding.Right,
            rec.Height - padding.Top - padding.Bottom);

        return recReturn;
    }
}
