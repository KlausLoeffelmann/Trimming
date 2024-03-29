using AutoColumnListViewDemo.DataSources;
using System.Collections.ObjectModel;

namespace AutoColumnListViewDemo;

public partial class FrmMain : Form
{
    public FrmMain()
    {
        InitializeComponent();
    }

    private async void BtnDeployDemoData_Click(object sender, EventArgs e)
    {
        var customers = new ObservableCollection<Customer>();
        _customerListView.DataContext = customers;
        await Customer.GenerateSampleRecordsAsync(customers, 100);
    }

    private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using FrmOptions optionsForm = new();
        if (optionsForm.ShowDialog() == DialogResult.OK)
        {
            _customerListView.KeyFilter = optionsForm.ColumnHeaderNames;
        }
    }
}
