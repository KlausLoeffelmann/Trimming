using DemoToolkit.Mvvm.DesktopGeneric.ValueConverters;
using DemoToolkit.Mvvm.WinForms.Controls;
using System.ComponentModel;
using TaskTamer.DTOs;
using TaskTamer.ViewModels;

namespace TaskTamer9.WinForms.Views
{
    public partial class TaskViewItem : GridViewItemTemplate
    {
        private string _taskName;
        private string? _taskDescription;
        private string? _category;
        private string? _project;

        private TaskItemStatus _taskStatus;
        private DateTimeOffset? _dueDate;
        private DateTimeOffset _dateCreated;
        private DateTimeOffset _dateLastModified;

        [Bindable(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? TaskDescription
        {
            get => _taskDescription;
            set
            {
                SetProperty(ref _taskDescription, value);
                OnTaskDescriptionChanged();
            }
        }

        [Bindable(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [TypeConverter(typeof(CategoryToStringConverter))]
        public string? Category
        {
            get => _category;
            set
            {
                SetProperty(ref _category, value);
                OnCategoryChanged();
            }
        }

        // This is a custom TypeConverter that converts a CategoryViewModel to a string.
        private class CategoryToStringConverter : ValueConverter<CategoryViewModel>
        {
            protected override CategoryViewModel FromString(string value) 
                => throw new NotImplementedException();

            protected override string ToString(CategoryViewModel? value) 
                => value is null ? "- - -" : value.Name;
        }

        [Bindable(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [TypeConverter(typeof(ProjectToStringConverter))]
        public string? Project
        {
            get => _project;
            set
            {
                SetProperty(ref _project, value);
                OnProjectChanged();
            }
        }

        // This is a custom TypeConverter that converts a ProjectViewModel to a string.
        private class ProjectToStringConverter : ValueConverter<ProjectViewModel>
        {
            protected override ProjectViewModel FromString(string value)
                => throw new NotImplementedException();

            protected override string ToString(ProjectViewModel? value)
                => value is null ? "- - -" : value.Name;
        }

        [Bindable(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TaskItemStatus TaskStatus
        {
            get => _taskStatus;
            set
            {
                SetProperty(ref _taskStatus, value);
                OnTaskStatusChanged();
            }
        }

        [Bindable(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [TypeConverter(typeof(DueDateToStringConverter))]

        public DateTimeOffset? DueDate
        {
            get => _dueDate;
            set
            {
                SetProperty(ref _dueDate, value);
                OnDueDateChanged();
            }
        }

        // This is a custom TypeConverter that converts a DateTimeOffset to a string.
        private class DueDateToStringConverter : ValueConverter<DateTimeOffset>
        {
            protected override DateTimeOffset FromString(string value)
                => throw new NotImplementedException();

            protected override string ToString(DateTimeOffset value)
                => value.ToString("d");
        }

        [Bindable(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTimeOffset DateCreated
        {
            get => _dateCreated;
            set
            {
                SetProperty(ref _dateCreated, value);
                OnDateCreatedChanged();
            }
        }

        [Bindable(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTimeOffset DateLastModified
        {
            get => _dateLastModified;
            set
            {
                SetProperty(ref _dateLastModified, value);
                OnDateLastModifiedChanged();
            }
        }
    }
}
