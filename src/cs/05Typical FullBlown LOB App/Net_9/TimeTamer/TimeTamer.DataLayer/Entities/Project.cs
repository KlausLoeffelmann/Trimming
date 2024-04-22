using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTamer.DataLayer.Models;

[Index(nameof(OwnerId), Name = "IDX_Project_Owner")]
public partial class Project
{
    [Key]
    public Guid ProjectId { get; set; }

    [StringLength(255)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTimeOffset? StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    public Guid? OwnerId { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    [StringLength(255)]
    public string? ExternalReference { get; set; }

    [ForeignKey(nameof(OwnerId))]
    [InverseProperty(nameof(User.Projects))]
    public virtual User? Owner { get; set; }

    [InverseProperty(nameof(Project.TaskItems))]
    public virtual ICollection<TaskItem> TaskItems { get; set; } = [];

    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateLastModified { get; set; }
    public Guid SyncId { get; set; }
}
