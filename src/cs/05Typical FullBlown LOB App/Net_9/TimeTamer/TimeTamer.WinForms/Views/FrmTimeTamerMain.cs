
using System.ComponentModel;

namespace TimeTamer.WinForms
{
    public partial class FrmTimeTamerMain : Form
    {
        public FrmTimeTamerMain()
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
            
            if (DataContext is INotifyPropertyChanged viewModel)
            {
                _timeTamerMainViewModelBindingSource.DataSource = viewModel;
            }
        }
    }
}
