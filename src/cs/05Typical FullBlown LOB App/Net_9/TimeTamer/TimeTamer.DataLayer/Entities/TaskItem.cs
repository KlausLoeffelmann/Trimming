using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskTamer.DTOs;

namespace TaskTamer.DataLayer.Models;

public partial class TaskItem
{
    [Key]
    public Guid TaskItemId { get; set; }

    [StringLength(255)]
    public string Name { get; set; } = null!;

    [ForeignKey(nameof(Category.CategoryId))]
    public Category? Category { get; set; }

    [ForeignKey(nameof(Project.ProjectId))]
    [InverseProperty(nameof(TaskTamerContext.TaskItems))]
    public virtual Project? Project { get; set; }

    public string? Description { get; set; }

    [ForeignKey(nameof(User.UserId))]
    [InverseProperty(nameof(TaskTamerContext.TaskItems))]
    public User Owner { get; set; } = null!;

    public DateTimeOffset? DueDate { get; set; }

    public TaskItemStatus Status { get; set; }

    [StringLength(255)]
    public string? ExternalReference { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public DateTimeOffset DateLastModified { get; set; }

    public Guid SyncId { get; set; }

    public static IEnumerable<TaskItem> GetTasksForUser(User currentUser)
    {
        using var context = new TaskTamerContext();

        var resultSet = context.TaskItems
            .Where(task => task.Owner == currentUser)
            .Include(task => task.Project)
            .Include(task => task.Owner)
            .Include(task => task.Category)
            .ToList();

        return resultSet;
    }
}
