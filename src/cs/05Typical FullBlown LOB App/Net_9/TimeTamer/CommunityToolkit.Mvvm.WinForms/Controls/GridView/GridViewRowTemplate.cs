namespace CommunityToolkit.Mvvm.WinForms.Controls;

public class GridViewRowTemplate : BindableComponent
{
    // Implement GetPreferredSize:
    protected virtual Size GetPreferredSize(Size proposedSize)
    {
        return new Size(0, 0);
    }

    protected virtual void OnPaintContent(PaintEventArgs e)
    {
        // Draw the content of the control
    }
}
