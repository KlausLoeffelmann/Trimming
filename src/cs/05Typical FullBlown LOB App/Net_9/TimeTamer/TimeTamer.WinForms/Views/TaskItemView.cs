using CommunityToolkit.Mvvm.WinForms.Controls;
using System.ComponentModel;
using TaskTamer.DTOs;

namespace TaskTamer9.WinForms.Views
{
    [ToolboxItem(true)]
    public class TaskItemView : GridViewItemTemplate
    {
        private string _taskName;
        private string? _taskDescription;
        private string? _category;
        private string? _project;

        private TaskItemStatus _taskStatus;
        private DateTimeOffset? _dueDate;
        private DateTimeOffset _dateCreated;
        private DateTimeOffset _dateLastModified;

        public event EventHandler? TaskNameChanged;
        public event EventHandler? TaskDescriptionChanged;
        public event EventHandler? CategoryChanged;
        public event EventHandler? ProjectChanged;
        public event EventHandler? TaskStatusChanged;
        public event EventHandler? DueDateChanged;
        public event EventHandler? DateCreatedChanged;
        public event EventHandler? DateLastModifiedChanged;

        // Rounded Rectangles

        public TaskItemView()
        {
            _taskName = string.Empty;
            TaskStatus = TaskItemStatus.Undefined;
        }

        [Bindable(true)]
        public string TaskName
        {
            get => _taskName;
            set
            {
                SetProperty(ref _taskName, value);
                OnTaskNameChanged();
            }
        }

        [Bindable(true)]
        public string? TaskDescription
        {
            get => _taskDescription;
            set
            {
                SetProperty(ref _taskDescription, value);
                OnTaskDescriptionChanged();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string? Category
        {
            get => _category;
            set
            {
                SetProperty(ref _category, value);
                OnCategoryChanged();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string? Project
        {
            get => _project;
            set
            {
                SetProperty(ref _project, value);
                OnProjectChanged();
            }
        }

        public TaskItemStatus TaskStatus
        {
            get => _taskStatus;
            set
            {
                SetProperty(ref _taskStatus, value);
                OnTaskStatusChanged();
            }
        }

        public DateTimeOffset? DueDate
        {
            get => _dueDate;
            set
            {
                SetProperty(ref _dueDate, value);
                OnDueDateChanged();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset DateCreated
        {
            get => _dateCreated;
            set
            {
                SetProperty(ref _dateCreated, value);
                OnDateCreatedChanged();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset DateLastModified
        {
            get => _dateLastModified;
            set
            {
                SetProperty(ref _dateLastModified, value);
                OnDateLastModifiedChanged();
            }
        }

        protected virtual void OnTaskNameChanged() 
            => TaskNameChanged?.Invoke(this, EventArgs.Empty);

        protected virtual void OnTaskDescriptionChanged() 
            => TaskDescriptionChanged?.Invoke(this, EventArgs.Empty);

        protected virtual void OnCategoryChanged() 
            => CategoryChanged?.Invoke(this, EventArgs.Empty);

        protected virtual void OnProjectChanged() 
            => ProjectChanged?.Invoke(this, EventArgs.Empty);

        protected virtual void OnTaskStatusChanged() 
            => TaskStatusChanged?.Invoke(this, EventArgs.Empty);

        protected virtual void OnDueDateChanged() 
            => DueDateChanged?.Invoke(this, EventArgs.Empty);

        protected virtual void OnDateCreatedChanged() 
            => DateCreatedChanged?.Invoke(this, EventArgs.Empty);

        protected virtual void OnDateLastModifiedChanged() 
            => DateLastModifiedChanged?.Invoke(this, EventArgs.Empty);
    }
}
