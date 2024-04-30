using DemoToolkit.Mvvm.WinForms.Controls;
using System.ComponentModel;
using TaskTamer.DTOs;

namespace TaskTamer9.WinForms.Views
{
    [ToolboxItem(true)]
    public partial class TaskViewItem : GridViewItemTemplate
    {
        private Font _taskNameFont = new("Segoe UI", 16, FontStyle.Bold);
        private Font _taskDescriptionFont = new("Segoe UI", 14, FontStyle.Regular);
        private Font _taskDetailsFont = new("Segoe UI", 11, FontStyle.Regular);

        private int _leadingOffset = 60;

        public TaskViewItem()
        {
            _taskName = string.Empty;
            TaskStatus = TaskItemStatus.Undefined;
        }

        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        public Font NameFont
        {
            get => _taskNameFont;
            set
            {
                if (_taskNameFont == value)
                    return;

                _taskNameFont = value;
            }
        }

        [Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        public Font DescriptionFont
        {
            get => _taskNameFont;
            set
            {
                if (_taskNameFont == value)
                    return;

                _taskNameFont = value;
            }
        }

        protected override Size GetPreferredSize(Size restrictedSize)
        {
            // For simplicity, we just return a fixed size for the height.
            // But we can as well calculate the height based on the content.
            return new(restrictedSize.Width, 140);
        }

        protected override void OnPaintContent(PaintEventArgs e, Rectangle clipBounds, bool isMouseOver)
        {
            // Do we have a vertical scrollbar?
            var hasVerticalScrollbar = e.ClipRectangle.Width < clipBounds.Width;

            // Here we're painting the context of the TaskViewItem:
            DrawBackground(e.Graphics, clipBounds, isMouseOver);
            DrawTaskCheckedRadioButton(e.Graphics, clipBounds);
            int taskNameHeight = DrawTaskName(e.Graphics, clipBounds);
            DrawEllipsedTaskDescription(e.Graphics, clipBounds, taskNameHeight);
            DrawDueDate(e.Graphics, clipBounds);
        }

        private void DrawBackground(Graphics graphics, Rectangle clipBounds, bool isMouseOver)
        {
            var backgroundColorBrush = isMouseOver
                ? base.HighlightedBackgroundColorBrush
                : base.ItemBackgroundColorBrush;

            graphics.FillRoundedRectangle(
                backgroundColorBrush, 
                clipBounds, 
                new(10, 10));
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

        private int DrawTaskName(Graphics graphics, Rectangle clipBounds)
        {
            // We need to draw it ellipsed if it's too long:
            var taskNameSize = TextRenderer.MeasureText(TaskName, _taskNameFont);

            RectangleF taskNameBounds = new(
                x: clipBounds.Left + _leadingOffset,
                y: clipBounds.Top + ContentPadding.Top,
                width: clipBounds.Width - _leadingOffset,
                height: taskNameSize.Height);

            if (taskNameSize.Width > taskNameBounds.Width)
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

            return taskNameSize.Height;
        }

        private void DrawEllipsedTaskDescription(Graphics graphics, Rectangle clipBounds, int taskNameHeight)
        {
            Rectangle taskDescriptionBounds = new(
                x: clipBounds.Left + 60,
                y: clipBounds.Top + taskNameHeight + ContentPadding.Top + LineSpacing,
                width: clipBounds.Width - 300,
                height: (int)(_taskDescriptionFont.GetHeight() * 2) + 20);

            // Now, we're measuring the multi-line height:
            TextRenderer.DrawText(
                graphics,
                TaskDescription,
                _taskDescriptionFont,
                taskDescriptionBounds,
                StandardFontColor,
                TextFormatFlags.WordEllipsis | TextFormatFlags.WordBreak);
        }

        private void DrawDueDate(Graphics graphics, Rectangle clipBounds)
        {
            string dueDate = DueDate?.ToString("ddd, MM/dd/yyyy HH:mm (K)") ?? "No Due Date";

            // We need to draw it ellipsed if it's too long:
            var dueDateSize = TextRenderer.MeasureText(dueDate, _taskDetailsFont);

            RectangleF dueDateBounds = new(
                x: clipBounds.Right - (ContentPadding.Right + Padding.Right + Padding.Left + dueDateSize.Width + clipBounds.X),
                y: clipBounds.Top + ContentPadding.Top,
                width: dueDateSize.Width,
                height: dueDateSize.Height);

            var brush = new SolidBrush(StandardFontColor);

            graphics.DrawString(
                dueDate,
                _taskDetailsFont,
                brush,
                dueDateBounds);
        }
    }
}
