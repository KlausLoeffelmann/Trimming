using System.Diagnostics;

namespace TaskTamer.WinForms;

public partial class FrmTaskTamerMain : Form
{
    public FrmTaskTamerMain()
    {
        InitializeComponent();

        // This is just for demo purposes.
        _demoInvokeAsyncMenuItem.Click += 
            (_,_) => _dateParsingSpinner.IsSpinning = !_dateParsingSpinner.IsSpinning;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        // This is where we are setting up the Binding for this view.
        // If set up correctly, at this point the IWinFormsStartService took care
        // of creating the ViewModel and setting it to the DataContext of this view.
        // So, we can now bind the controls to the ViewModel properties.
        _mainVmSource.DataSource = DataContext;
    }

    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        _entDueDate.Focus();
    }
}
