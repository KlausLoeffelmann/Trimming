using AutoColumnListViewDemo.Controls;

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
            _btnDeployDemoData = new Button();
            _customerListView = new AutoColumnListView();
            SuspendLayout();
            // 
            // _btnDeployDemoData
            // 
            _btnDeployDemoData.Location = new Point(315, 361);
            _btnDeployDemoData.Name = "_btnDeployDemoData";
            _btnDeployDemoData.Size = new Size(173, 43);
            _btnDeployDemoData.TabIndex = 1;
            _btnDeployDemoData.Text = "Populate Demo Data";
            _btnDeployDemoData.UseVisualStyleBackColor = true;
            _btnDeployDemoData.Click += _btnDeployDemoData_Click;
            // 
            // _customerListView
            // 
            _customerListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _customerListView.FullRowSelect = true;
            _customerListView.GridLines = true;
            _customerListView.ItemType = typeof(DataSources.Customer);
            _customerListView.Location = new Point(11, 12);
            _customerListView.Name = "_customerListView";
            _customerListView.Size = new Size(819, 325);
            _customerListView.TabIndex = 2;
            _customerListView.UseCompatibleStateImageBehavior = false;
            _customerListView.View = View.Details;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(843, 423);
            Controls.Add(_customerListView);
            Controls.Add(_btnDeployDemoData);
            Name = "FrmMain";
            Text = "AutoColumnListView - Demo";
            ResumeLayout(false);
        }

        #endregion
        private Button _btnDeployDemoData;
        private AutoColumnListView _customerListView;
    }
}
