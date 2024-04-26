using System.ComponentModel;
using System.Diagnostics;

namespace TaskTamer.WinForms;

public partial class FrmTaskTamerMain : Form
{
    public FrmTaskTamerMain()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        // This is where we are setting up the Binding for this view.
        // If set up correctly, at this point the IWinFormsStartService took care
        // of creating the ViewModel and setting it to the DataContext of this view.
        // So, we can now bind the controls to the ViewModel properties.
        _mainViewModelBindingSource.DataSource = DataContext;
    }

    private void _cmbProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        Debug.Print($"Selected Project: {_cmbProject.SelectedItem}");
    }
}
