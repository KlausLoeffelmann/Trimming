﻿using DemoToolkit.Mvvm.WinForms.AI;
using DemoToolkit.Mvvm.WinForms.Controls;
using DemoToolkit.Mvvm.WinForms.Controls.ModernEntry;

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
            _mainVmSource = new BindingSource(components);
            _lblCurrentUser = new ToolStripStatusLabel();
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
            toolStripMenuItem3 = new ToolStripMenuItem();
            orderByDueDateToolStripMenuItem = new ToolStripMenuItem();
            orderByLastModifiedToolStripMenuItem = new ToolStripMenuItem();
            orderByStatusToolStripMenuItem = new ToolStripMenuItem();
            testsToolStripMenuItem = new ToolStripMenuItem();
            _demoInvokeAsyncMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            _tasksGridView = new GridView();
            _taskItemView = new TaskTamer9.WinForms.Views.TaskItemView();
            _taskVmSource = new BindingSource(components);
            _addTaskGroupBox = new ModernGroupBox();
            _tlpNewTaskOuter = new TableLayoutPanel();
            _tlpNewTaskParams = new TableLayoutPanel();
            _lblProject = new Label();
            _lblDueDate = new Label();
            _cmbProject = new BindableComboBox();
            _projectsSource = new BindingSource(components);
            _entDueDate = new ModernDateOffsetEntry();
            _dateParsingSpinner = new SpinnerControl();
            _tlpNewTask = new TableLayoutPanel();
            _btnNewTask = new ModernCommandButton();
            _optNewTaskDone = new RadioButton();
            _entNewTask = new ModernStringEntry();
            _semanticKernel = new SemanticKernelBaseComponent();
            _statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_mainVmSource).BeginInit();
            _mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_tasksGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_taskVmSource).BeginInit();
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
            _statusStrip.Location = new Point(0, 482);
            _statusStrip.Margin = new Padding(0, 0, 3, 0);
            _statusStrip.Name = "_statusStrip";
            _statusStrip.Padding = new Padding(1, 0, 16, 0);
            _statusStrip.RenderMode = ToolStripRenderMode.ManagerRenderMode;
            _statusStrip.Size = new Size(939, 36);
            _statusStrip.TabIndex = 3;
            _statusStrip.Text = "statusStrip1";
            // 
            // _lblSpringLabel
            // 
            _lblSpringLabel.DataBindings.Add(new Binding("Text", _mainVmSource, "SelectedProject", true));
            _lblSpringLabel.Name = "_lblSpringLabel";
            _lblSpringLabel.Size = new Size(709, 31);
            _lblSpringLabel.Spring = true;
            _lblSpringLabel.Text = "#SelectedTasksProjectSpring#";
            _lblSpringLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // _mainVmSource
            // 
            _mainVmSource.DataSource = typeof(ViewModels.MainViewModel);
            // 
            // _lblCurrentUser
            // 
            _lblCurrentUser.DataBindings.Add(new Binding("Text", _mainVmSource, "CurrentUser", true));
            _lblCurrentUser.Name = "_lblCurrentUser";
            _lblCurrentUser.Size = new Size(60, 31);
            _lblCurrentUser.Text = "#User#";
            // 
            // _lblDateTime
            // 
            _lblDateTime.DataBindings.Add(new Binding("Text", _mainVmSource, "CurrentDisplayTime", true));
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
            _mainMenuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, baseDataToolStripMenuItem, toolStripMenuItem3, testsToolStripMenuItem, toolsToolStripMenuItem });
            _mainMenuStrip.Location = new Point(0, 0);
            _mainMenuStrip.Name = "_mainMenuStrip";
            _mainMenuStrip.Padding = new Padding(12, 5, 5, 5);
            _mainMenuStrip.Size = new Size(939, 35);
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
            baseDataToolStripMenuItem.Size = new Size(48, 25);
            baseDataToolStripMenuItem.Text = "Edit";
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
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { orderByDueDateToolStripMenuItem, orderByLastModifiedToolStripMenuItem, orderByStatusToolStripMenuItem });
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(56, 25);
            toolStripMenuItem3.Text = "View";
            // 
            // orderByDueDateToolStripMenuItem
            // 
            orderByDueDateToolStripMenuItem.Name = "orderByDueDateToolStripMenuItem";
            orderByDueDateToolStripMenuItem.Size = new Size(240, 26);
            orderByDueDateToolStripMenuItem.Text = "Order by Due Date";
            // 
            // orderByLastModifiedToolStripMenuItem
            // 
            orderByLastModifiedToolStripMenuItem.Name = "orderByLastModifiedToolStripMenuItem";
            orderByLastModifiedToolStripMenuItem.Size = new Size(240, 26);
            orderByLastModifiedToolStripMenuItem.Text = "Order by Last Modified";
            // 
            // orderByStatusToolStripMenuItem
            // 
            orderByStatusToolStripMenuItem.Name = "orderByStatusToolStripMenuItem";
            orderByStatusToolStripMenuItem.Size = new Size(240, 26);
            orderByStatusToolStripMenuItem.Text = "Order by Status";
            // 
            // testsToolStripMenuItem
            // 
            testsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { _demoInvokeAsyncMenuItem });
            testsToolStripMenuItem.Name = "testsToolStripMenuItem";
            testsToolStripMenuItem.Size = new Size(55, 25);
            testsToolStripMenuItem.Text = "&Tests";
            // 
            // _demoInvokeAsyncMenuItem
            // 
            _demoInvokeAsyncMenuItem.Name = "_demoInvokeAsyncMenuItem";
            _demoInvokeAsyncMenuItem.Size = new Size(206, 26);
            _demoInvokeAsyncMenuItem.Text = "&Generate test data";
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
            _tasksGridView.DataBindings.Add(new Binding("SelectedItem", _mainVmSource, "SelectedProject", true, DataSourceUpdateMode.OnPropertyChanged));
            _tasksGridView.DataBindings.Add(new Binding("DataContext", _mainVmSource, "Tasks", true));
            _tasksGridView.DataContext = null;
            _tasksGridView.GridViewItemTemplate = _taskItemView;
            _tasksGridView.Location = new Point(14, 52);
            _tasksGridView.Margin = new Padding(4, 3, 4, 3);
            _tasksGridView.Name = "_tasksGridView";
            _tasksGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _tasksGridView.Size = new Size(912, 242);
            _tasksGridView.TabIndex = 1;
            _tasksGridView.VirtualMode = true;
            // 
            // _taskItemView
            // 
            _taskItemView.DataBindings.Add(new Binding("TaskDescription", _taskVmSource, "Description", true));
            _taskItemView.DataBindings.Add(new Binding("TaskName", _taskVmSource, "Name", true));
            _taskItemView.DataBindings.Add(new Binding("DueDate", _taskVmSource, "DueDate", true));
            _taskItemView.DataBindings.Add(new Binding("TaskStatus", _taskVmSource, "Status", true));
            _taskItemView.Padding = new Padding(5, 5, 5, 0);
            // 
            // _taskVmSource
            // 
            _taskVmSource.DataSource = typeof(ViewModels.TaskViewModel);
            // 
            // _addTaskGroupBox
            // 
            _addTaskGroupBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _addTaskGroupBox.Controls.Add(_tlpNewTaskOuter);
            _addTaskGroupBox.Location = new Point(14, 308);
            _addTaskGroupBox.Margin = new Padding(4, 3, 4, 3);
            _addTaskGroupBox.Name = "_addTaskGroupBox";
            _addTaskGroupBox.Size = new Size(912, 164);
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
            _tlpNewTaskOuter.Size = new Size(827, 105);
            _tlpNewTaskOuter.TabIndex = 0;
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
            _tlpNewTaskParams.Controls.Add(_entDueDate, 3, 0);
            _tlpNewTaskParams.Controls.Add(_dateParsingSpinner, 4, 0);
            _tlpNewTaskParams.Dock = DockStyle.Fill;
            _tlpNewTaskParams.Location = new Point(4, 3);
            _tlpNewTaskParams.Margin = new Padding(4, 3, 4, 3);
            _tlpNewTaskParams.Name = "_tlpNewTaskParams";
            _tlpNewTaskParams.RowCount = 1;
            _tlpNewTaskParams.RowStyles.Add(new RowStyle());
            _tlpNewTaskParams.Size = new Size(819, 43);
            _tlpNewTaskParams.TabIndex = 0;
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
            _lblDueDate.Location = new Point(417, 11);
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
            _cmbProject.DataBindings.Add(new Binding("SelectedItem", _mainVmSource, "SelectedProject", true, DataSourceUpdateMode.OnPropertyChanged));
            _cmbProject.DataSource = _projectsSource;
            _cmbProject.DropDownHeight = 100;
            _cmbProject.FormattingEnabled = true;
            _cmbProject.IntegralHeight = false;
            _cmbProject.Location = new Point(123, 10);
            _cmbProject.Name = "_cmbProject";
            _cmbProject.SelectedBindingValue = null;
            _cmbProject.Size = new Size(262, 29);
            _cmbProject.TabIndex = 1;
            // 
            // _projectsSource
            // 
            _projectsSource.DataMember = "Projects";
            _projectsSource.DataSource = _mainVmSource;
            // 
            // _entDueDate
            // 
            _entDueDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            _entDueDate.AutoSize = true;
            _entDueDate.DataBindings.Add(new Binding("Value", _mainVmSource, "NewTaskDueDate", true, DataSourceUpdateMode.OnPropertyChanged));
            _entDueDate.Location = new Point(501, 3);
            _entDueDate.MakeItIntelligent = true;
            _entDueDate.Name = "_entDueDate";
            _entDueDate.SemanticKernelComponent = _semanticKernel;
            _entDueDate.Size = new Size(262, 37);
            _entDueDate.Spinner = _dateParsingSpinner;
            _entDueDate.TabIndex = 3;
            // 
            // _dateParsingSpinner
            // 
            _dateParsingSpinner.Anchor = AnchorStyles.None;
            _dateParsingSpinner.AutoSize = true;
            _dateParsingSpinner.IsSpinning = false;
            _dateParsingSpinner.Location = new Point(785, 11);
            _dateParsingSpinner.Name = "_dateParsingSpinner";
            _dateParsingSpinner.Size = new Size(14, 21);
            _dateParsingSpinner.TabIndex = 4;
            _dateParsingSpinner.Text = " ";
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
            _tlpNewTask.Controls.Add(_entNewTask, 1, 0);
            _tlpNewTask.Dock = DockStyle.Fill;
            _tlpNewTask.Location = new Point(3, 52);
            _tlpNewTask.Name = "_tlpNewTask";
            _tlpNewTask.RowCount = 1;
            _tlpNewTask.RowStyles.Add(new RowStyle());
            _tlpNewTask.Size = new Size(821, 43);
            _tlpNewTask.TabIndex = 1;
            // 
            // _btnNewTask
            // 
            _btnNewTask.Anchor = AnchorStyles.None;
            _btnNewTask.DataBindings.Add(new Binding("Command", _mainVmSource, "AddTaskCommand", true));
            _btnNewTask.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            _btnNewTask.Location = new Point(771, 5);
            _btnNewTask.Margin = new Padding(3, 3, 3, 0);
            _btnNewTask.Name = "_btnNewTask";
            _btnNewTask.Size = new Size(47, 35);
            _btnNewTask.TabIndex = 1;
            _btnNewTask.Text = " ";
            _btnNewTask.UseVisualStyleBackColor = true;
            // 
            // _optNewTaskDone
            // 
            _optNewTaskDone.Anchor = AnchorStyles.None;
            _optNewTaskDone.Location = new Point(10, 9);
            _optNewTaskDone.Margin = new Padding(10, 3, 3, 3);
            _optNewTaskDone.Name = "_optNewTaskDone";
            _optNewTaskDone.Size = new Size(16, 25);
            _optNewTaskDone.TabIndex = 2;
            _optNewTaskDone.TabStop = true;
            _optNewTaskDone.UseVisualStyleBackColor = true;
            // 
            // _entNewTask
            // 
            _entNewTask.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            _entNewTask.AutoSize = true;
            _entNewTask.DataBindings.Add(new Binding("Value", _mainVmSource, "NewTaskName", true, DataSourceUpdateMode.OnPropertyChanged));
            _entNewTask.Location = new Point(32, 3);
            _entNewTask.Name = "_entNewTask";
            _entNewTask.Size = new Size(733, 37);
            _entNewTask.TabIndex = 0;
            // 
            // _semanticKernel
            // 
            _semanticKernel.AssistantInstructions = "";
            // 
            // FrmTaskTamerMain
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(939, 518);
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
            ((System.ComponentModel.ISupportInitialize)_mainVmSource).EndInit();
            _mainMenuStrip.ResumeLayout(false);
            _mainMenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_tasksGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)_taskVmSource).EndInit();
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
        private ToolStripMenuItem _demoInvokeAsyncMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripStatusLabel _lblSpringLabel;
        private DemoToolkit.Mvvm.WinForms.Controls.GridView _tasksGridView;
        private TaskTamer9.WinForms.Views.TaskItemView _taskItemView;
        private BindingSource _mainVmSource;
        private BindingSource _taskVmSource;
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
        private ModernStringEntry _entNewTask;
        private ModernDateOffsetEntry _entDueDate;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem orderByDueDateToolStripMenuItem;
        private ToolStripMenuItem orderByLastModifiedToolStripMenuItem;
        private ToolStripMenuItem orderByStatusToolStripMenuItem;
        private SpinnerControl _dateParsingSpinner;
    }
}
