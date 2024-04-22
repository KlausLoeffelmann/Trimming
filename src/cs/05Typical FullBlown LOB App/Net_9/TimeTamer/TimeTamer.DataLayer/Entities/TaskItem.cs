using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTamer.DataLayer.Models;

[Index("AssignedToUserId", Name = "IDX_TaskItem_AssignedTo")]
[Index("ProjectId", Name = "IDX_TaskItem_Project")]
public partial class TaskItem
{
    [Key]
    public Guid TaskItemId { get; set; }

    public Guid? ProjectId { get; set; }

    [StringLength(255)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public Guid? AssignedToUserId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DueDate { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    [StringLength(255)]
    public string? ExternalReference { get; set; }

    [ForeignKey(nameof(AssignedToUserId))]
    [InverseProperty(nameof(TimeTamerContext.TaskItems))]
    public virtual User? AssignedToUser { get; set; }

    [ForeignKey(nameof(Project.ProjectId))]
    [InverseProperty(nameof(TimeTamerContext.TaskItems))]
    public virtual Project? Project { get; set; }

    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateLastModified { get; set; }
    public Guid SyncId { get; set; }
}
