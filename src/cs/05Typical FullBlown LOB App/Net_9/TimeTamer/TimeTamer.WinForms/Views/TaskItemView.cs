using CommunityToolkit.Mvvm.WinForms.Controls;
using System.ComponentModel;
using TaskTamer.DTOs;

namespace TaskTamer9.WinForms.Views
{
    [ToolboxItem(true)]
    public partial class TaskItemView : GridViewItemTemplate
    {
        private string _taskName;
        private string? _taskDescription;
        private string? _category;
        private string? _project;

        private Font _taskNameFont = new("Segoe UI", 14, FontStyle.Bold);
        private Font _taskDescriptionFont = new("Segoe UI", 11, FontStyle.Regular);

        private TaskItemStatus _taskStatus;
        private DateTimeOffset? _dueDate;
        private DateTimeOffset _dateCreated;
        private DateTimeOffset _dateLastModified;

        public TaskItemView()
        {
            _taskName = string.Empty;
            TaskStatus = TaskItemStatus.Undefined;
        }

        protected override Size GetPreferredSize(Size restrictedSize)
        {
            // For simplicity, we just return a fixed size for the height.
            // But we can as well calculate the height based on the content.
            return new(restrictedSize.Width, 150);
        }

        protected override void OnPaintContent(PaintEventArgs e, Rectangle clipBounds, bool isMouseOver)
        {
            // Do we have a vertical scrollbar?
            var hasVerticalScrollbar = e.ClipRectangle.Width < clipBounds.Width;


            // Here we're painting the context of the TaskViewItem:
            DrawBackground(e.Graphics, clipBounds, isMouseOver);
            DrawTaskCheckedRadioButton(e.Graphics, clipBounds);
            DrawTaskName(e.Graphics, clipBounds);
            DrawEllipsedTaskDescription(e.Graphics, clipBounds);
            DrawDueDate(e.Graphics, clipBounds);
        }

        private void DrawBackground(Graphics graphics, Rectangle clipBounds, bool isMouseOver)
        {
            var backgroundColorBrush = isMouseOver 
                ? base.HighlightedBackgroundColorBrush 
                : base.ItemBackgroundColorBrush;

            graphics.FillRoundedRectangle(backgroundColorBrush, clipBounds, new(10,10));
        }

        private void DrawTaskCheckedRadioButton(Graphics graphics, Rectangle clipBounds)
        {
            // Should be painted on the left side of the TaskViewItem.

            // Let's get the ButtonState based on the TaskStatus:
            var buttonState = (IsDarkMode ? ButtonState.Flat : ButtonState.Normal) 
                | TaskStatus switch
                {
                    TaskItemStatus.Completed => ButtonState.Checked,
                    TaskItemStatus.Canceled => ButtonState.Inactive,
                    TaskItemStatus.NotStarted => ButtonState.Normal,
                    TaskItemStatus.InProgress => ButtonState.Pushed,
                    TaskItemStatus.Undefined => ButtonState.Inactive,
                    _ => ButtonState.Normal
                };

            Rectangle taskRadioButtonBounds = new(
                x: clipBounds.Left + 10,
                y: clipBounds.Top + 30,
                width: 30,
                height: 30);

            ControlPaint.DrawRadioButton(
                graphics,
                taskRadioButtonBounds,
                buttonState);
        }

        private void DrawTaskName(Graphics graphics, Rectangle clipBounds)
        {
            // Should be painted on the top left corner of the TaskViewItem.

            RectangleF taskNameBounds = new(
                x: clipBounds.Left + 60,
                y: clipBounds.Top + 15,
                width: clipBounds.Width - 60,
                height: 30);

            // We need to draw it ellipsed if it's too long:
            var taskName = TextRenderer.MeasureText(TaskName, _taskNameFont);

            if (taskName.Width > taskNameBounds.Width)
            {
                TextRenderer.DrawText(
                    graphics,
                    TaskName,
                    _taskNameFont,
                    Rectangle.Round(taskNameBounds),
                    HighlightFontColor,
                    TextFormatFlags.EndEllipsis);
            }
            else
            {
                var brush = new SolidBrush(HighlightFontColor);
                graphics.DrawString(TaskName, _taskNameFont, brush, taskNameBounds);
            }
        }

        private void DrawEllipsedTaskDescription(Graphics graphics, Rectangle clipBounds)
        {
            RectangleF taskDescriptionBounds = new(
                x: clipBounds.Left + 60,
                y: clipBounds.Top + 60,
                width: clipBounds.Width - 60,
                height: 80);

            // We need to draw it ellipsed if it's too long:
            var taskDescription = TextRenderer.MeasureText(TaskDescription, _taskDescriptionFont);
            if (taskDescription.Width > taskDescriptionBounds.Width)
            {
                TextRenderer.DrawText(
                    graphics,
                    TaskDescription,
                    _taskDescriptionFont,
                    Rectangle.Round(taskDescriptionBounds),
                    StandardFontColor,
                    TextFormatFlags.EndEllipsis);
            }
            else
            {
                var brush = new SolidBrush(StandardFontColor);
                graphics.DrawString(TaskDescription, _taskDescriptionFont, brush, taskDescriptionBounds);
            }
        }

        private void DrawDueDate(Graphics graphics, Rectangle clipBounds)
        {
            RectangleF dueDateBounds = new(
                x: clipBounds.Right - 100,
                y: clipBounds.Top + 10,
                width: 90,
                height: 20);

            var brush = new SolidBrush(StandardFontColor);

            graphics.DrawString(
                DueDate?.ToString("dd/MM/yyyy") ?? "No Due Date",
                _taskDescriptionFont,
                brush,
                dueDateBounds);
        }

        [Bindable(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        public TaskItemStatus TaskStatus
        {
            get => _taskStatus;
            set
            {
                SetProperty(ref _taskStatus, value);
                OnTaskStatusChanged();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
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
    }
}
