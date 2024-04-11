namespace TimeTamer.WinForms
{
    partial class FrmTimeTamerMain
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
            components = new System.ComponentModel.Container();
            _statusStrip = new StatusStrip();
            _lblSpringLabel = new ToolStripStatusLabel();
            _lblDateTime = new ToolStripStatusLabel();
            _lblCurrentUser = new ToolStripStatusLabel();
            timeTamerMainViewModelBindingSource = new BindingSource(components);
            _mainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            quitToolStripMenuItem = new ToolStripMenuItem();
            baseDataToolStripMenuItem = new ToolStripMenuItem();
            usersToolStripMenuItem = new ToolStripMenuItem();
            prToolStripMenuItem = new ToolStripMenuItem();
            catagoriesToolStripMenuItem = new ToolStripMenuItem();
            testsToolStripMenuItem = new ToolStripMenuItem();
            generateTestDataToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            _dataGridTasks = new DataGridView();
            _statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timeTamerMainViewModelBindingSource).BeginInit();
            _mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_dataGridTasks).BeginInit();
            SuspendLayout();
            // 
            // _statusStrip
            // 
            _statusStrip.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _statusStrip.ImageScalingSize = new Size(20, 20);
            _statusStrip.Items.AddRange(new ToolStripItem[] { _lblSpringLabel, _lblDateTime, _lblCurrentUser });
            _statusStrip.Location = new Point(0, 721);
            _statusStrip.Name = "_statusStrip";
            _statusStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            _statusStrip.Size = new Size(1072, 37);
            _statusStrip.TabIndex = 0;
            _statusStrip.Text = "statusStrip1";
            // 
            // _lblSpringLabel
            // 
            _lblSpringLabel.Name = "_lblSpringLabel";
            _lblSpringLabel.Padding = new Padding(3);
            _lblSpringLabel.Size = new Size(960, 31);
            _lblSpringLabel.Spring = true;
            _lblSpringLabel.Text = "#";
            _lblSpringLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _lblDateTime
            // 
            _lblDateTime.DataBindings.Add(new Binding("Text", timeTamerMainViewModelBindingSource, "CurrentDisplayTime", true));
            _lblDateTime.Name = "_lblDateTime";
            _lblDateTime.Padding = new Padding(3);
            _lblDateTime.Size = new Size(29, 31);
            _lblDateTime.Text = "#";
            // 
            // _lblCurrentUser
            // 
            _lblCurrentUser.DataBindings.Add(new Binding("Text", timeTamerMainViewModelBindingSource, "CurrentDisplayTime", true, DataSourceUpdateMode.OnPropertyChanged));
            _lblCurrentUser.Name = "_lblCurrentUser";
            _lblCurrentUser.Padding = new Padding(3);
            _lblCurrentUser.Size = new Size(29, 31);
            _lblCurrentUser.Text = "#";
            // 
            // timeTamerMainViewModelBindingSource
            // 
            timeTamerMainViewModelBindingSource.DataSource = typeof(ViewModels.TimeTamerMainViewModel);
            // 
            // _mainMenuStrip
            // 
            _mainMenuStrip.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _mainMenuStrip.ImageScalingSize = new Size(20, 20);
            _mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, baseDataToolStripMenuItem, testsToolStripMenuItem, toolsToolStripMenuItem });
            _mainMenuStrip.Location = new Point(0, 0);
            _mainMenuStrip.Name = "_mainMenuStrip";
            _mainMenuStrip.Padding = new Padding(10, 5, 5, 5);
            _mainMenuStrip.Size = new Size(1072, 39);
            _mainMenuStrip.TabIndex = 1;
            _mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportToolStripMenuItem, importToolStripMenuItem, toolStripMenuItem1, quitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(52, 29);
            fileToolStripMenuItem.Text = "&File";
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(165, 30);
            exportToolStripMenuItem.Text = "&Export...";
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(165, 30);
            importToolStripMenuItem.Text = "&Import...";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(162, 6);
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(165, 30);
            quitToolStripMenuItem.Text = "&Quit";
            // 
            // baseDataToolStripMenuItem
            // 
            baseDataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { usersToolStripMenuItem, prToolStripMenuItem, catagoriesToolStripMenuItem });
            baseDataToolStripMenuItem.Name = "baseDataToolStripMenuItem";
            baseDataToolStripMenuItem.Size = new Size(90, 29);
            baseDataToolStripMenuItem.Text = "&Manage";
            // 
            // usersToolStripMenuItem
            // 
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new Size(194, 30);
            usersToolStripMenuItem.Text = "Users...";
            // 
            // prToolStripMenuItem
            // 
            prToolStripMenuItem.Name = "prToolStripMenuItem";
            prToolStripMenuItem.Size = new Size(194, 30);
            prToolStripMenuItem.Text = "&Projects...";
            // 
            // catagoriesToolStripMenuItem
            // 
            catagoriesToolStripMenuItem.Name = "catagoriesToolStripMenuItem";
            catagoriesToolStripMenuItem.Size = new Size(194, 30);
            catagoriesToolStripMenuItem.Text = "Catagories...";
            // 
            // testsToolStripMenuItem
            // 
            testsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generateTestDataToolStripMenuItem });
            testsToolStripMenuItem.Name = "testsToolStripMenuItem";
            testsToolStripMenuItem.Size = new Size(64, 29);
            testsToolStripMenuItem.Text = "&Tests";
            // 
            // generateTestDataToolStripMenuItem
            // 
            generateTestDataToolStripMenuItem.Name = "generateTestDataToolStripMenuItem";
            generateTestDataToolStripMenuItem.Size = new Size(242, 30);
            generateTestDataToolStripMenuItem.Text = "&Generate test data";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { optionsToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(67, 29);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(174, 30);
            optionsToolStripMenuItem.Text = "&Options...";
            // 
            // _dataGridTasks
            // 
            _dataGridTasks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _dataGridTasks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            _dataGridTasks.Location = new Point(12, 42);
            _dataGridTasks.Name = "_dataGridTasks";
            _dataGridTasks.RowHeadersWidth = 51;
            _dataGridTasks.Size = new Size(1048, 676);
            _dataGridTasks.TabIndex = 2;
            // 
            // FrmTimeTamerMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1072, 758);
            Controls.Add(_dataGridTasks);
            Controls.Add(_statusStrip);
            Controls.Add(_mainMenuStrip);
            MainMenuStrip = _mainMenuStrip;
            Margin = new Padding(4);
            Name = "FrmTimeTamerMain";
            Text = "Time Tamer";
            _statusStrip.ResumeLayout(false);
            _statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)timeTamerMainViewModelBindingSource).EndInit();
            _mainMenuStrip.ResumeLayout(false);
            _mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_dataGridTasks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip _statusStrip;
        private MenuStrip _mainMenuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem quitToolStripMenuItem;
        private ToolStripMenuItem baseDataToolStripMenuItem;
        private ToolStripMenuItem usersToolStripMenuItem;
        private ToolStripStatusLabel _lblDateTime;
        private ToolStripStatusLabel _lblCurrentUser;
        private ToolStripMenuItem prToolStripMenuItem;
        private ToolStripMenuItem catagoriesToolStripMenuItem;
        private DataGridView _dataGridTasks;
        private ToolStripMenuItem testsToolStripMenuItem;
        private ToolStripMenuItem generateTestDataToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripStatusLabel _lblSpringLabel;
        private BindingSource timeTamerMainViewModelBindingSource;
    }
}
