using DemoToolkit.Mvvm.WinForms.Controls;

namespace TaskTamer9.WinForms.Views
{
    public partial class TaskViewItem : GridViewItemTemplate
    {
        public event EventHandler? TaskNameChanged;
        public event EventHandler? TaskDescriptionChanged;
        public event EventHandler? CategoryChanged;
        public event EventHandler? ProjectChanged;
        public event EventHandler? TaskStatusChanged;
        public event EventHandler? DueDateChanged;
        public event EventHandler? DateCreatedChanged;
        public event EventHandler? DateLastModifiedChanged;

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
