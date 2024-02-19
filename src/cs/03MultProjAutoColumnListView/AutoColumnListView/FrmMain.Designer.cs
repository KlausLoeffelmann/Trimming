using WinFormsControls;

namespace AutoColumnListViewDemo
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            _btnDeployDemoData = new Button();
            _customerListView = new AutoColumnListView();
            SuspendLayout();
            // 
            // _btnDeployDemoData
            // 
            resources.ApplyResources(_btnDeployDemoData, "_btnDeployDemoData");
            _btnDeployDemoData.Name = "_btnDeployDemoData";
            _btnDeployDemoData.UseVisualStyleBackColor = true;
            _btnDeployDemoData.Click += BtnDeployDemoData_Click;
            // 
            // _customerListView
            // 
            _customerListView.FullRowSelect = true;
            _customerListView.GridLines = true;
            _customerListView.ItemType = typeof(DataSources.Customer);
            resources.ApplyResources(_customerListView, "_customerListView");
            _customerListView.Name = "_customerListView";
            _customerListView.UseCompatibleStateImageBehavior = false;
            _customerListView.View = View.Details;
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(_customerListView);
            Controls.Add(_btnDeployDemoData);
            Name = "FrmMain";
            ResumeLayout(false);
        }

        #endregion
        private Button _btnDeployDemoData;
        private AutoColumnListView _customerListView;
    }
}
