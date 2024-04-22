using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    [Column(TypeName = "datetime")]
    public DateTime? DueDate { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    [StringLength(255)]
    public string? ExternalReference { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public DateTimeOffset DateLastModified { get; set; }

    public Guid SyncId { get; set; }
}
