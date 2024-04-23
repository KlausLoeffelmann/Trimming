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
            categoriesToolStripMenuItem = new ToolStripMenuItem();
            prToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            usersToolStripMenuItem = new ToolStripMenuItem();
            testsToolStripMenuItem = new ToolStripMenuItem();
            generateTestDataToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            _tasksGridView = new CommunityToolkit.Mvvm.WinForms.Controls.GridView();
            _taskItemView = new TaskTamer9.WinForms.Views.TaskItemView();
            taskViewModelBindingSource = new BindingSource(components);
            dataGridViewColumn2 = new DataGridViewColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewColumn1 = new DataGridViewColumn();
            dataGridViewColumn3 = new DataGridViewColumn();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            radioButton1 = new RadioButton();
            dataGridViewColumn4 = new DataGridViewColumn();
            dataGridViewColumn5 = new DataGridViewColumn();
            dataGridViewColumn6 = new DataGridViewColumn();
            dataGridViewColumn7 = new DataGridViewColumn();
            dataGridViewColumn8 = new DataGridViewColumn();
            dataGridViewColumn9 = new DataGridViewColumn();
            dataGridViewColumn10 = new DataGridViewColumn();
            dataGridViewColumn11 = new DataGridViewColumn();
            dataGridViewColumn12 = new DataGridViewColumn();
            dataGridViewColumn13 = new DataGridViewColumn();
            _statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_mainViewModelBindingSource).BeginInit();
            _mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_tasksGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)taskViewModelBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // _statusStrip
            // 
            resources.ApplyResources(_statusStrip, "_statusStrip");
            _statusStrip.GripMargin = new Padding(5);
            _statusStrip.GripStyle = ToolStripGripStyle.Visible;
            _statusStrip.ImageScalingSize = new Size(20, 20);
            _statusStrip.Items.AddRange(new ToolStripItem[] { _lblSpringLabel, _lblCurrentUser, _lblDateTime });
            _statusStrip.Name = "_statusStrip";
            _statusStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            // 
            // _lblSpringLabel
            // 
            _lblSpringLabel.Name = "_lblSpringLabel";
            resources.ApplyResources(_lblSpringLabel, "_lblSpringLabel");
            _lblSpringLabel.Spring = true;
            // 
            // _lblCurrentUser
            // 
            _lblCurrentUser.DataBindings.Add(new Binding("Text", _mainViewModelBindingSource, "CurrentUserInfo", true));
            _lblCurrentUser.Name = "_lblCurrentUser";
            resources.ApplyResources(_lblCurrentUser, "_lblCurrentUser");
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
            _lblDateTime.Padding = new Padding(5);
            resources.ApplyResources(_lblDateTime, "_lblDateTime");
            // 
            // _mainMenuStrip
            // 
            resources.ApplyResources(_mainMenuStrip, "_mainMenuStrip");
            _mainMenuStrip.ImageScalingSize = new Size(20, 20);
            _mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, baseDataToolStripMenuItem, testsToolStripMenuItem, toolsToolStripMenuItem });
            _mainMenuStrip.Name = "_mainMenuStrip";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportToolStripMenuItem, importToolStripMenuItem, toolStripMenuItem1, quitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            resources.ApplyResources(exportToolStripMenuItem, "exportToolStripMenuItem");
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            resources.ApplyResources(importToolStripMenuItem, "importToolStripMenuItem");
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            resources.ApplyResources(quitToolStripMenuItem, "quitToolStripMenuItem");
            // 
            // baseDataToolStripMenuItem
            // 
            baseDataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { categoriesToolStripMenuItem, prToolStripMenuItem, toolStripMenuItem2, usersToolStripMenuItem });
            baseDataToolStripMenuItem.Name = "baseDataToolStripMenuItem";
            resources.ApplyResources(baseDataToolStripMenuItem, "baseDataToolStripMenuItem");
            // 
            // categoriesToolStripMenuItem
            // 
            categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            resources.ApplyResources(categoriesToolStripMenuItem, "categoriesToolStripMenuItem");
            // 
            // prToolStripMenuItem
            // 
            prToolStripMenuItem.Name = "prToolStripMenuItem";
            resources.ApplyResources(prToolStripMenuItem, "prToolStripMenuItem");
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // usersToolStripMenuItem
            // 
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            resources.ApplyResources(usersToolStripMenuItem, "usersToolStripMenuItem");
            // 
            // testsToolStripMenuItem
            // 
            testsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generateTestDataToolStripMenuItem });
            testsToolStripMenuItem.Name = "testsToolStripMenuItem";
            resources.ApplyResources(testsToolStripMenuItem, "testsToolStripMenuItem");
            // 
            // generateTestDataToolStripMenuItem
            // 
            generateTestDataToolStripMenuItem.Name = "generateTestDataToolStripMenuItem";
            resources.ApplyResources(generateTestDataToolStripMenuItem, "generateTestDataToolStripMenuItem");
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { optionsToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // _tasksGridView
            // 
            _tasksGridView.AllowUserToAddRows = false;
            _tasksGridView.AllowUserToDeleteRows = false;
            resources.ApplyResources(_tasksGridView, "_tasksGridView");
            _tasksGridView.DataBindings.Add(new Binding("DataContext", _mainViewModelBindingSource, "Tasks", true));
            _tasksGridView.DataContext = null;
            _tasksGridView.GridViewItemTemplate = _taskItemView;
            _tasksGridView.Name = "_tasksGridView";
            _tasksGridView.VirtualMode = true;
            // 
            // _taskItemView
            // 
            _taskItemView.Category = null;
            _taskItemView.DataBindings.Add(new Binding("TaskDescription", taskViewModelBindingSource, "Description", true));
            _taskItemView.DataBindings.Add(new Binding("TaskName", taskViewModelBindingSource, "Name", true));
            _taskItemView.DataBindings.Add(new Binding("DueDate", taskViewModelBindingSource, "DueDate", true));
            _taskItemView.DataBindings.Add(new Binding("TaskStatus", taskViewModelBindingSource, "Status", true));
            _taskItemView.DateCreated = (DateTimeOffset)resources.GetObject("_taskItemView.DateCreated");
            _taskItemView.DateLastModified = (DateTimeOffset)resources.GetObject("_taskItemView.DateLastModified");
            _taskItemView.DueDate = null;
            _taskItemView.Padding = new Padding(5);
            _taskItemView.Project = null;
            _taskItemView.TaskDescription = null;
            _taskItemView.TaskName = "";
            _taskItemView.TaskStatus = DTOs.TaskItemStatus.Undefined;
            // 
            // taskViewModelBindingSource
            // 
            taskViewModelBindingSource.DataSource = typeof(ViewModels.TaskViewModel);
            // 
            // dataGridViewColumn2
            // 
            resources.ApplyResources(dataGridViewColumn2, "dataGridViewColumn2");
            dataGridViewColumn2.Name = "dataGridViewColumn2";
            // 
            // dataGridViewTextBoxColumn1
            // 
            resources.ApplyResources(dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewColumn1
            // 
            resources.ApplyResources(dataGridViewColumn1, "dataGridViewColumn1");
            dataGridViewColumn1.Name = "dataGridViewColumn1";
            // 
            // dataGridViewColumn3
            // 
            resources.ApplyResources(dataGridViewColumn3, "dataGridViewColumn3");
            dataGridViewColumn3.Name = "dataGridViewColumn3";
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            resources.ApplyResources(textBox1, "textBox1");
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Name = "textBox1";
            // 
            // radioButton1
            // 
            resources.ApplyResources(radioButton1, "radioButton1");
            radioButton1.Name = "radioButton1";
            radioButton1.TabStop = true;
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewColumn4
            // 
            resources.ApplyResources(dataGridViewColumn4, "dataGridViewColumn4");
            dataGridViewColumn4.Name = "dataGridViewColumn4";
            // 
            // dataGridViewColumn5
            // 
            resources.ApplyResources(dataGridViewColumn5, "dataGridViewColumn5");
            dataGridViewColumn5.Name = "dataGridViewColumn5";
            // 
            // dataGridViewColumn6
            // 
            resources.ApplyResources(dataGridViewColumn6, "dataGridViewColumn6");
            dataGridViewColumn6.Name = "dataGridViewColumn6";
            // 
            // dataGridViewColumn7
            // 
            resources.ApplyResources(dataGridViewColumn7, "dataGridViewColumn7");
            dataGridViewColumn7.Name = "dataGridViewColumn7";
            // 
            // dataGridViewColumn8
            // 
            resources.ApplyResources(dataGridViewColumn8, "dataGridViewColumn8");
            dataGridViewColumn8.Name = "dataGridViewColumn8";
            // 
            // dataGridViewColumn9
            // 
            resources.ApplyResources(dataGridViewColumn9, "dataGridViewColumn9");
            dataGridViewColumn9.Name = "dataGridViewColumn9";
            // 
            // dataGridViewColumn10
            // 
            resources.ApplyResources(dataGridViewColumn10, "dataGridViewColumn10");
            dataGridViewColumn10.Name = "dataGridViewColumn10";
            // 
            // dataGridViewColumn11
            // 
            resources.ApplyResources(dataGridViewColumn11, "dataGridViewColumn11");
            dataGridViewColumn11.Name = "dataGridViewColumn11";
            // 
            // dataGridViewColumn12
            // 
            resources.ApplyResources(dataGridViewColumn12, "dataGridViewColumn12");
            dataGridViewColumn12.Name = "dataGridViewColumn12";
            // 
            // dataGridViewColumn13
            // 
            resources.ApplyResources(dataGridViewColumn13, "dataGridViewColumn13");
            dataGridViewColumn13.Name = "dataGridViewColumn13";
            // 
            // FrmTaskTamerMain
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Controls.Add(_tasksGridView);
            Controls.Add(_statusStrip);
            Controls.Add(_mainMenuStrip);
            MainMenuStrip = _mainMenuStrip;
            Name = "FrmTaskTamerMain";
            _statusStrip.ResumeLayout(false);
            _statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_mainViewModelBindingSource).EndInit();
            _mainMenuStrip.ResumeLayout(false);
            _mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_tasksGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)taskViewModelBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
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
        private DataGridViewColumn dataGridViewColumn1;
        private BindingSource taskViewModelBindingSource;
        private DataGridViewColumn dataGridViewColumn2;
        private DataGridViewColumn dataGridViewColumn3;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private RadioButton radioButton1;
        private DataGridViewColumn dataGridViewColumn4;
        private DataGridViewColumn dataGridViewColumn5;
        private DataGridViewColumn dataGridViewColumn6;
        private DataGridViewColumn dataGridViewColumn7;
        private DataGridViewColumn dataGridViewColumn8;
        private DataGridViewColumn dataGridViewColumn9;
        private DataGridViewColumn dataGridViewColumn10;
        private DataGridViewColumn dataGridViewColumn11;
        private DataGridViewColumn dataGridViewColumn12;
        private ToolStripSeparator toolStripMenuItem2;
        private DataGridViewColumn dataGridViewColumn13;
    }
}
