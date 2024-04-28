using System.ComponentModel;
using TaskTamer.DataLayer.Models;

namespace TaskTamer.ViewModels;

public partial class TaskViewModel
{
    public class TaskViewModelTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType) 
            => destinationType == typeof(string) 
                || destinationType == typeof(DateTimeOffset)
                || destinationType == typeof(ProjectViewModel)
                || base.CanConvertTo(context, destinationType);

        public override object? ConvertTo(
            ITypeDescriptorContext? context, 
            System.Globalization.CultureInfo? culture, 
            object? value, 
            Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value is TaskItem taskItem)
                {
                    return taskItem.Name;
                }
            }
            else if (destinationType == typeof(DateTimeOffset))
            {
                if (value is TaskItem taskItem)
                {
                    return taskItem.DueDate;
                }
            }
            else if (typeof(ProjectViewModel).IsAssignableFrom(destinationType) 
                && value is TaskViewModel taskViewModel)
            {
                return taskViewModel.Project;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
