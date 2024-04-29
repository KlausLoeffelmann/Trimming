namespace TaskTamer.WinForms;

public partial class FrmTaskTamerMain : Form
{
    public FrmTaskTamerMain()
    {
        InitializeComponent();

        #region Some preps for VERY cool value entry support...😉

        // This is just for demo purposes.
        _demoInvokeAsyncMenuItem.Click +=
            (_, _) => _dateParsingSpinner.IsSpinning = !_dateParsingSpinner.IsSpinning;

        _entDueDate.RequestApiKey += (_, e) => e.ApiKey = Environment.GetEnvironmentVariable("AI:OpenAi:ApiKey");
        _entNewTask.RequestApiKey += (_, e) => e.ApiKey = Environment.GetEnvironmentVariable("AI:OpenAi:ApiKey");

        #endregion
    }

    // This is where we are setting up the Binding for this view.
    // We just assign the DataContext to the DataSource of the BindingSource.
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        _mainVmSource.DataSource = DataContext;
    }
}
