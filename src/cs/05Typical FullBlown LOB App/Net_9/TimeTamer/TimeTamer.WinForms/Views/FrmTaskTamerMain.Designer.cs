﻿using CommunityToolkit.Mvvm.WinForms.AI;
using CommunityToolkit.Mvvm.WinForms.Controls;
using CommunityToolkit.Mvvm.WinForms.Controls.ModernEntry;

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
            _statusStrip = new StatusStrip();
            _lblSpringLabel = new ToolStripStatusLabel();
            _lblCurrentUser = new ToolStripStatusLabel();
            _mainViewModelSource = new BindingSource(components);
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
            _tasksGridView = new GridView();
            _taskItemView = new TaskTamer9.WinForms.Views.TaskItemView();
            _taskViewModelSource = new BindingSource(components);
            _addTaskGroupBox = new ModernGroupBox();
            _tlpNewTaskOuter = new TableLayoutPanel();
            _tlpNewTaskParams = new TableLayoutPanel();
            _lblProject = new Label();
            _lblDueDate = new Label();
            _cmbProject = new BindableComboBox();
            _projectsSource = new BindingSource(components);
            modernDateEntry1 = new ModernDateEntry();
            _tlpNewTask = new TableLayoutPanel();
            _btnNewTask = new ModernCommandButton();
            _optNewTaskDone = new RadioButton();
            modernStringEntry1 = new ModernStringEntry();
            _semanticKernel = new SemanticKernelBaseComponent();
            _statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_mainViewModelSource).BeginInit();
            _mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_tasksGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_taskViewModelSource).BeginInit();
            _addTaskGroupBox.SuspendLayout();
            _tlpNewTaskOuter.SuspendLayout();
            _tlpNewTaskParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_projectsSource).BeginInit();
            _tlpNewTask.SuspendLayout();
            SuspendLayout();
            // 
            // _statusStrip
            // 
            _statusStrip.Font = new Font("Segoe UI", 12F);
            _statusStrip.GripMargin = new Padding(5);
            _statusStrip.GripStyle = ToolStripGripStyle.Visible;
            _statusStrip.ImageScalingSize = new Size(20, 20);
            _statusStrip.Items.AddRange(new ToolStripItem[] { _lblSpringLabel, _lblCurrentUser, _lblDateTime });
            _statusStrip.Location = new Point(0, 515);
            _statusStrip.Margin = new Padding(0, 0, 3, 0);
            _statusStrip.Name = "_statusStrip";
            _statusStrip.Padding = new Padding(1, 0, 16, 0);
            _statusStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            _statusStrip.Size = new Size(976, 36);
            _statusStrip.TabIndex = 3;
            _statusStrip.Text = "statusStrip1";
            // 
            // _lblSpringLabel
            // 
            _lblSpringLabel.Name = "_lblSpringLabel";
            _lblSpringLabel.Size = new Size(746, 31);
            _lblSpringLabel.Spring = true;
            _lblSpringLabel.Text = "#SelectedTaskSpring#";
            _lblSpringLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _lblCurrentUser
            // 
            _lblCurrentUser.DataBindings.Add(new Binding("Text", _mainViewModelSource, "CurrentUser", true));
            _lblCurrentUser.Name = "_lblCurrentUser";
            _lblCurrentUser.Size = new Size(60, 31);
            _lblCurrentUser.Text = "#User#";
            // 
            // _mainViewModelSource
            // 
            _mainViewModelSource.DataSource = typeof(ViewModels.MainViewModel);
            // 
            // _lblDateTime
            // 
            _lblDateTime.DataBindings.Add(new Binding("Text", _mainViewModelSource, "CurrentDisplayTime", true));
            _lblDateTime.DisplayStyle = ToolStripItemDisplayStyle.Text;
            _lblDateTime.Margin = new Padding(0, 3, 2, 2);
            _lblDateTime.Name = "_lblDateTime";
            _lblDateTime.Padding = new Padding(5);
            _lblDateTime.Size = new Size(151, 31);
            _lblDateTime.Text = "#DatePlaceholder#";
            // 
            // _mainMenuStrip
            // 
            _mainMenuStrip.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _mainMenuStrip.ImageScalingSize = new Size(20, 20);
            _mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, baseDataToolStripMenuItem, testsToolStripMenuItem, toolsToolStripMenuItem });
            _mainMenuStrip.Location = new Point(0, 0);
            _mainMenuStrip.Name = "_mainMenuStrip";
            _mainMenuStrip.Padding = new Padding(12, 5, 5, 5);
            _mainMenuStrip.Size = new Size(976, 35);
            _mainMenuStrip.TabIndex = 0;
            _mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportToolStripMenuItem, importToolStripMenuItem, toolStripMenuItem1, quitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 25);
            fileToolStripMenuItem.Text = "&File";
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            exportToolStripMenuItem.Size = new Size(136, 26);
            exportToolStripMenuItem.Text = "&Export...";
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(136, 26);
            importToolStripMenuItem.Text = "&Import...";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(133, 6);
            // 
            // quitToolStripMenuItem
            // 
            quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            quitToolStripMenuItem.Size = new Size(136, 26);
            quitToolStripMenuItem.Text = "&Quit";
            // 
            // baseDataToolStripMenuItem
            // 
            baseDataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { categoriesToolStripMenuItem, prToolStripMenuItem, toolStripMenuItem2, usersToolStripMenuItem });
            baseDataToolStripMenuItem.Name = "baseDataToolStripMenuItem";
            baseDataToolStripMenuItem.Size = new Size(78, 25);
            baseDataToolStripMenuItem.Text = "&Manage";
            // 
            // categoriesToolStripMenuItem
            // 
            categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            categoriesToolStripMenuItem.Size = new Size(163, 26);
            categoriesToolStripMenuItem.Text = "Categories...";
            // 
            // prToolStripMenuItem
            // 
            prToolStripMenuItem.Name = "prToolStripMenuItem";
            prToolStripMenuItem.Size = new Size(163, 26);
            prToolStripMenuItem.Text = "&Projects...";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(160, 6);
            // 
            // usersToolStripMenuItem
            // 
            usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            usersToolStripMenuItem.Size = new Size(163, 26);
            usersToolStripMenuItem.Text = "Users...";
            // 
            // testsToolStripMenuItem
            // 
            testsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { generateTestDataToolStripMenuItem });
            testsToolStripMenuItem.Name = "testsToolStripMenuItem";
            testsToolStripMenuItem.Size = new Size(55, 25);
            testsToolStripMenuItem.Text = "&Tests";
            // 
            // generateTestDataToolStripMenuItem
            // 
            generateTestDataToolStripMenuItem.Name = "generateTestDataToolStripMenuItem";
            generateTestDataToolStripMenuItem.Size = new Size(206, 26);
            generateTestDataToolStripMenuItem.Text = "&Generate test data";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { optionsToolStripMenuItem });
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(57, 25);
            toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(144, 26);
            optionsToolStripMenuItem.Text = "&Options...";
            // 
            // _tasksGridView
            // 
            _tasksGridView.AllowUserToAddRows = false;
            _tasksGridView.AllowUserToDeleteRows = false;
            _tasksGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _tasksGridView.BorderStyle = BorderStyle.None;
            _tasksGridView.DataBindings.Add(new Binding("DataContext", _mainViewModelSource, "Tasks", true));
            _tasksGridView.DataContext = null;
            _tasksGridView.GridViewItemTemplate = _taskItemView;
            _tasksGridView.Location = new Point(14, 52);
            _tasksGridView.Margin = new Padding(4, 3, 4, 3);
            _tasksGridView.Name = "_tasksGridView";
            _tasksGridView.Size = new Size(949, 275);
            _tasksGridView.TabIndex = 1;
            _tasksGridView.VirtualMode = true;
            // 
            // _taskItemView
            // 
            _taskItemView.DataBindings.Add(new Binding("TaskDescription", _taskViewModelSource, "Description", true));
            _taskItemView.DataBindings.Add(new Binding("TaskName", _taskViewModelSource, "Name", true));
            _taskItemView.DataBindings.Add(new Binding("DueDate", _taskViewModelSource, "DueDate", true));
            _taskItemView.DataBindings.Add(new Binding("TaskStatus", _taskViewModelSource, "Status", true));
            _taskItemView.Padding = new Padding(5, 5, 5, 0);
            // 
            // _taskViewModelSource
            // 
            _taskViewModelSource.DataSource = typeof(ViewModels.TaskViewModel);
            // 
            // _addTaskGroupBox
            // 
            _addTaskGroupBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _addTaskGroupBox.Controls.Add(_tlpNewTaskOuter);
            _addTaskGroupBox.Location = new Point(14, 341);
            _addTaskGroupBox.Margin = new Padding(4, 3, 4, 3);
            _addTaskGroupBox.Name = "_addTaskGroupBox";
            _addTaskGroupBox.Size = new Size(949, 164);
            _addTaskGroupBox.TabIndex = 2;
            _addTaskGroupBox.TabStop = false;
            _addTaskGroupBox.Text = "Add a new task:";
            _addTaskGroupBox.TextMargin = new Rectangle(10, 0, 20, 10);
            // 
            // _tlpNewTaskOuter
            // 
            _tlpNewTaskOuter.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            _tlpNewTaskOuter.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _tlpNewTaskOuter.ColumnCount = 1;
            _tlpNewTaskOuter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _tlpNewTaskOuter.Controls.Add(_tlpNewTaskParams, 0, 0);
            _tlpNewTaskOuter.Controls.Add(_tlpNewTask, 0, 1);
            _tlpNewTaskOuter.Location = new Point(28, 49);
            _tlpNewTaskOuter.Margin = new Padding(4, 3, 4, 3);
            _tlpNewTaskOuter.Name = "_tlpNewTaskOuter";
            _tlpNewTaskOuter.RowCount = 3;
            _tlpNewTaskOuter.RowStyles.Add(new RowStyle());
            _tlpNewTaskOuter.RowStyles.Add(new RowStyle());
            _tlpNewTaskOuter.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            _tlpNewTaskOuter.Size = new Size(864, 105);
            _tlpNewTaskOuter.TabIndex = 6;
            // 
            // _tlpNewTaskParams
            // 
            _tlpNewTaskParams.AutoSize = true;
            _tlpNewTaskParams.ColumnCount = 5;
            _tlpNewTaskParams.ColumnStyles.Add(new ColumnStyle());
            _tlpNewTaskParams.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _tlpNewTaskParams.ColumnStyles.Add(new ColumnStyle());
            _tlpNewTaskParams.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _tlpNewTaskParams.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 53F));
            _tlpNewTaskParams.Controls.Add(_lblProject, 0, 0);
            _tlpNewTaskParams.Controls.Add(_lblDueDate, 2, 0);
            _tlpNewTaskParams.Controls.Add(_cmbProject, 1, 0);
            _tlpNewTaskParams.Controls.Add(modernDateEntry1, 3, 0);
            _tlpNewTaskParams.Dock = DockStyle.Fill;
            _tlpNewTaskParams.Location = new Point(4, 3);
            _tlpNewTaskParams.Margin = new Padding(4, 3, 4, 3);
            _tlpNewTaskParams.Name = "_tlpNewTaskParams";
            _tlpNewTaskParams.RowCount = 1;
            _tlpNewTaskParams.RowStyles.Add(new RowStyle());
            _tlpNewTaskParams.Size = new Size(856, 43);
            _tlpNewTaskParams.TabIndex = 5;
            // 
            // _lblProject
            // 
            _lblProject.Anchor = AnchorStyles.Right;
            _lblProject.AutoSize = true;
            _lblProject.Location = new Point(55, 11);
            _lblProject.Margin = new Padding(55, 0, 4, 0);
            _lblProject.Name = "_lblProject";
            _lblProject.Size = new Size(61, 21);
            _lblProject.TabIndex = 0;
            _lblProject.Text = "Project:";
            // 
            // _lblDueDate
            // 
            _lblDueDate.Anchor = AnchorStyles.Right;
            _lblDueDate.AutoSize = true;
            _lblDueDate.Location = new Point(435, 11);
            _lblDueDate.Margin = new Padding(29, 0, 4, 0);
            _lblDueDate.Name = "_lblDueDate";
            _lblDueDate.Size = new Size(77, 21);
            _lblDueDate.TabIndex = 2;
            _lblDueDate.Text = "Due Date:";
            _lblDueDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // _cmbProject
            // 
            _cmbProject.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            _cmbProject.BindingValue = null;
            _cmbProject.DataBindings.Add(new Binding("BindingValue", _mainViewModelSource, "SelectedProject", true, DataSourceUpdateMode.OnPropertyChanged));
            _cmbProject.DataSource = _projectsSource;
            _cmbProject.DropDownHeight = 100;
            _cmbProject.FormattingEnabled = true;
            _cmbProject.IntegralHeight = false;
            _cmbProject.Location = new Point(123, 7);
            _cmbProject.Name = "_cmbProject";
            _cmbProject.Size = new Size(280, 29);
            _cmbProject.TabIndex = 4;
            // 
            // _projectsSource
            // 
            _projectsSource.DataMember = "Projects";
            _projectsSource.DataSource = _mainViewModelSource;
            // 
            // modernDateEntry1
            // 
            modernDateEntry1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            modernDateEntry1.AutoSize = true;
            modernDateEntry1.Location = new Point(519, 3);
            modernDateEntry1.Name = "modernDateEntry1";
            modernDateEntry1.OriginalInputText = null;
            modernDateEntry1.Size = new Size(280, 37);
            modernDateEntry1.TabIndex = 5;
            // 
            // _tlpNewTask
            // 
            _tlpNewTask.AutoSize = true;
            _tlpNewTask.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            _tlpNewTask.ColumnCount = 3;
            _tlpNewTask.ColumnStyles.Add(new ColumnStyle());
            _tlpNewTask.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            _tlpNewTask.ColumnStyles.Add(new ColumnStyle());
            _tlpNewTask.Controls.Add(_btnNewTask, 2, 0);
            _tlpNewTask.Controls.Add(_optNewTaskDone, 0, 0);
            _tlpNewTask.Controls.Add(modernStringEntry1, 1, 0);
            _tlpNewTask.Dock = DockStyle.Fill;
            _tlpNewTask.Location = new Point(3, 52);
            _tlpNewTask.Name = "_tlpNewTask";
            _tlpNewTask.RowCount = 1;
            _tlpNewTask.RowStyles.Add(new RowStyle());
            _tlpNewTask.Size = new Size(858, 43);
            _tlpNewTask.TabIndex = 4;
            // 
            // _btnNewTask
            // 
            _btnNewTask.Anchor = AnchorStyles.None;
            _btnNewTask.DataBindings.Add(new Binding("Command", _mainViewModelSource, "AddTaskCommand", true));
            _btnNewTask.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _btnNewTask.Location = new Point(808, 5);
            _btnNewTask.Margin = new Padding(3, 3, 3, 0);
            _btnNewTask.Name = "_btnNewTask";
            _btnNewTask.Size = new Size(47, 35);
            _btnNewTask.TabIndex = 0;
            _btnNewTask.Text = " ";
            _btnNewTask.UseVisualStyleBackColor = true;
            // 
            // _optNewTaskDone
            // 
            _optNewTaskDone.Anchor = AnchorStyles.None;
            _optNewTaskDone.Location = new Point(3, 9);
            _optNewTaskDone.Name = "_optNewTaskDone";
            _optNewTaskDone.Size = new Size(27, 25);
            _optNewTaskDone.TabIndex = 0;
            _optNewTaskDone.TabStop = true;
            _optNewTaskDone.UseVisualStyleBackColor = true;
            // 
            // modernStringEntry1
            // 
            modernStringEntry1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            modernStringEntry1.AutoSize = true;
            modernStringEntry1.Location = new Point(36, 3);
            modernStringEntry1.Name = "modernStringEntry1";
            modernStringEntry1.OriginalInputText = null;
            modernStringEntry1.Size = new Size(766, 37);
            modernStringEntry1.TabIndex = 1;
            modernStringEntry1.Value = "123456789";
            // 
            // _semanticKernel
            // 
            _semanticKernel.AssistantInstructions = "";
            // 
            // FrmTaskTamerMain
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(976, 551);
            Controls.Add(_addTaskGroupBox);
            Controls.Add(_tasksGridView);
            Controls.Add(_statusStrip);
            Controls.Add(_mainMenuStrip);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MainMenuStrip = _mainMenuStrip;
            Margin = new Padding(4);
            Name = "FrmTaskTamerMain";
            Text = "Task Tamer - .NET 9 Prerelase Demo. And yes. It's WinForms.";
            _statusStrip.ResumeLayout(false);
            _statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_mainViewModelSource).EndInit();
            _mainMenuStrip.ResumeLayout(false);
            _mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_tasksGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)_taskViewModelSource).EndInit();
            _addTaskGroupBox.ResumeLayout(false);
            _tlpNewTaskOuter.ResumeLayout(false);
            _tlpNewTaskOuter.PerformLayout();
            _tlpNewTaskParams.ResumeLayout(false);
            _tlpNewTaskParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_projectsSource).EndInit();
            _tlpNewTask.ResumeLayout(false);
            _tlpNewTask.PerformLayout();
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
        private BindingSource _mainViewModelSource;
        private BindingSource _taskViewModelSource;
        private ToolStripSeparator toolStripMenuItem2;
        private ModernGroupBox _addTaskGroupBox;
        private TableLayoutPanel _tlpNewTask;
        private ModernCommandButton _btnNewTask;
        private RadioButton _optNewTaskDone;
        private TableLayoutPanel _tlpNewTaskParams;
        private Label _lblProject;
        private Label _lblDueDate;
        private TableLayoutPanel _tlpNewTaskOuter;
        private BindingSource _projectsSource;
        private BindableComboBox _cmbProject;
        private SemanticKernelBaseComponent _semanticKernel;
        private ModernDateEntry modernDateEntry1;
        private ModernStringEntry modernStringEntry1;
    }
}
