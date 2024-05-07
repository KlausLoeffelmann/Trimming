using System.ComponentModel;

namespace TaskTamer.WinForms.Views;

public partial class frmManageUsers : Form
{
    public frmManageUsers()
    {
        InitializeComponent();
    }

    private void frmManageUsers_Load(object sender, EventArgs e)
    {

    }
}

[ToolboxItem(true)]
public class GridViewPanel : ToolStripPanel
{

}
