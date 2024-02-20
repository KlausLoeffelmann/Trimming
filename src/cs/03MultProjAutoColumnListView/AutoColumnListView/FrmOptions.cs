using AutoColumnListViewDemo.DataSources;

namespace AutoColumnListViewDemo
{
    public partial class FrmOptions : Form
    {
        private Type _schemaType;

        public FrmOptions()
        {
            InitializeComponent();
            _schemaType = typeof(Customer);
            UpdateGrid();
        }

        public Type SchemaType
        {
            get => _schemaType;
            set
            {
                if (value == _schemaType)
                {
                    return;
                }

                _schemaType = value;
                UpdateGrid();
            }
        }

        private void UpdateGrid()
        {
            _schemaSelectorControl.SchemaType = _schemaType;
        }

        public string[] ColumnHeaderNames => _schemaSelectorControl.ColumnHeaderNames;
    }
}
