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
            autoColumnListView1 = new AutoColumnListView();
            SuspendLayout();
            // 
            // _btnDeployDemoData
            // 
            _btnDeployDemoData.Location = new Point(276, 271);
            _btnDeployDemoData.Margin = new Padding(3, 2, 3, 2);
            _btnDeployDemoData.Name = "_btnDeployDemoData";
            _btnDeployDemoData.Size = new Size(151, 32);
            _btnDeployDemoData.TabIndex = 1;
            _btnDeployDemoData.Text = "Populate Demo Data";
            _btnDeployDemoData.UseVisualStyleBackColor = true;
            // 
            // autoColumnListView1
            // 
            autoColumnListView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            autoColumnListView1.FullRowSelect = true;
            autoColumnListView1.GridLines = true;
            autoColumnListView1.ItemType = typeof(DataSources.Customer);
            autoColumnListView1.Location = new Point(10, 9);
            autoColumnListView1.Margin = new Padding(3, 2, 3, 2);
            autoColumnListView1.Name = "autoColumnListView1";
            autoColumnListView1.Size = new Size(717, 241);
            autoColumnListView1.TabIndex = 2;
            autoColumnListView1.UseCompatibleStateImageBehavior = false;
            autoColumnListView1.View = View.Details;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 345);
            Controls.Add(autoColumnListView1);
            Controls.Add(_btnDeployDemoData);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmMain";
            Text = "AutoColumnListView - Demo";
            ResumeLayout(false);
        }

        #endregion
        private Button _btnDeployDemoData;
        private AutoColumnListView autoColumnListView1;
    }
}
