namespace TaskTamer.WinForms
{
    partial class FrmTaskTamerMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTaskTamerMain));
            _statusStrip = new StatusStrip();
            _lblSpringLabel = new ToolStripStatusLabel();
            _lblCurrentUser = new ToolStripStatusLabel();
            _mainViewModelBindingSource = new BindingSource(components);
            _lblDateTime = new ToolStripStatusLabel();
            _mainMenuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            quitToolStripMenuItem = new ToolStripMenuItem();
            baseDataToolStripMenuItem = new ToolStripMenuItem();
            usersToolStripMenuItem = new ToolStripMenuItem();
            prToolStripMenuItem = new ToolStripMenuItem();
            categoriesToolStripMenuItem = new ToolStripMenuItem();
            testsToolStripMenuItem = new ToolStripMenuItem();
            generateTestDataToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            _tasksGridView = new CommunityToolkit.Mvvm.WinForms.Controls.GridView();
            _taskItemView = new TaskTamer9.WinForms.Views.TaskItemView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            _statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_mainViewModelBindingSource).BeginInit();
            _mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_tasksGridView).BeginInit();
            SuspendLayout();
            // 
            // _statusStrip
            // 
            _statusStrip.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _statusStrip.GripMargin = new Padding(5);
            _statusStrip.GripStyle = ToolStripGripStyle.Visible;
            _statusStrip.ImageScalingSize = new Size(20, 20);
            _statusStrip.Items.AddRange(new ToolStripItem[] { _lblSpringLabel, _lblCurrentUser, _lblDateTime });
            _statusStrip.Location = new Point(0, 543);
            _statusStrip.Margin = new Padding(0, 0, 2, 0);
            _statusStrip.Name = "_statusStrip";
            _statusStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            _statusStrip.Size = new Size(1048, 31);
            _statusStrip.TabIndex = 0;
            _statusStrip.Text = "statusStrip1";
            // 
            // _lblSpringLabel
            // 
            _lblSpringLabel.Name = "_lblSpringLabel";
            _lblSpringLabel.Size = new Size(800, 25);
            _lblSpringLabel.Spring = true;
            _lblSpringLabel.Text = "#Spring#";
            _lblSpringLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _lblCurrentUser
            // 
            _lblCurrentUser.DataBindings.Add(new Binding("Text", _mainViewModelBindingSource, "CurrentUserInfo", true));
            _lblCurrentUser.Name = "_lblCurrentUser";
            _lblCurrentUser.Size = new Size(69, 25);
            _lblCurrentUser.Text = "#User#";
            // 
            // _mainViewModelBindingSource
            // 
            _mainViewModelBindingSource.DataSource = typeof(ViewModels.MainViewModel);
            // 
            // _lblDateTime
            // 
            _lblDateTime.DataBindings.Add(new Binding("Text", _mainViewModelBindingSource, "CurrentDisplayTime", true));
            _lblDateTime.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _lblDateTime.Margin = new Padding(0, 3, 2, 2);
            _lblDateTime.Name = "_lblDateTime";
            _lblDateTime.Size = new Size(162, 26);
            _lblDateTime.Text = "#DatePlaceholder#";
            // 
            // _mainMenuStrip
            // 
            _mainMenuStrip.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _mainMenuStrip.ImageScalingSize = new Size(20, 20);
            _mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, baseDataToolStripMenuItem, testsToolStripMenuItem, toolsToolStripMenuItem });
            _mainMenuStrip.Location = new Point(0, 0);
            _mainMenuStrip.Name = "_mainMenuStrip";
            _mainMenuStrip.Padding = new Padding(10, 5, 5, 5);
            _mainMenuStrip.Size = new Size(1048, 39);
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
            baseDataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { usersToolStripMenuItem, prToolStripMenuItem, categoriesToolStripMenuItem });
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
            // categoriesToolStripMenuItem
            // 
            categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            categoriesToolStripMenuItem.Size = new Size(194, 30);
            categoriesToolStripMenuItem.Text = "Categories...";
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
            // _tasksGridView
            // 
            _tasksGridView.AllowUserToAddRows = false;
            _tasksGridView.AllowUserToDeleteRows = false;
            _tasksGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _tasksGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1 });
            _tasksGridView.DataBindings.Add(new Binding("DataContext", _mainViewModelBindingSource, "Tasks", true));
            _tasksGridView.GridViewItemTemplate = _taskItemView;
            _tasksGridView.Location = new Point(12, 58);
            _tasksGridView.Name = "_tasksGridView";
            _tasksGridView.Size = new Size(1024, 464);
            _tasksGridView.TabIndex = 2;
            _tasksGridView.VirtualMode = true;
            // 
            // _taskItemView
            // 
            _taskItemView.Category = null;
            _taskItemView.DateCreated = (DateTimeOffset)resources.GetObject("_taskItemView.DateCreated");
            _taskItemView.DateLastModified = (DateTimeOffset)resources.GetObject("_taskItemView.DateLastModified");
            _taskItemView.DueDate = null;
            _taskItemView.Project = null;
            _taskItemView.TaskDescription = null;
            _taskItemView.TaskName = "";
            _taskItemView.TaskStatus = DTOs.TaskItemStatus.Undefined;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "CustomDataRowObject";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmTaskTamerMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1048, 574);
            Controls.Add(_tasksGridView);
            Controls.Add(_statusStrip);
            Controls.Add(_mainMenuStrip);
            MainMenuStrip = _mainMenuStrip;
            Margin = new Padding(4);
            Name = "FrmTaskTamerMain";
            Text = "Time Tamer";
            _statusStrip.ResumeLayout(false);
            _statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_mainViewModelBindingSource).EndInit();
            _mainMenuStrip.ResumeLayout(false);
            _mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_tasksGridView).EndInit();
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
        private ToolStripMenuItem categoriesToolStripMenuItem;
        private ToolStripMenuItem testsToolStripMenuItem;
        private ToolStripMenuItem generateTestDataToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripStatusLabel _lblSpringLabel;
        private CommunityToolkit.Mvvm.WinForms.Controls.GridView _tasksGridView;
        private TaskTamer9.WinForms.Views.TaskItemView _taskItemView;
        private BindingSource _mainViewModelBindingSource;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    }
}
