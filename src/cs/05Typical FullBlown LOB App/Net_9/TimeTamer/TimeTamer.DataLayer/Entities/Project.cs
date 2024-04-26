using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTamer.DataLayer.Models;

public partial class Project
{
    [Key]
    public Guid ProjectId { get; set; }

    [Required, StringLength(255)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [ForeignKey(nameof(Category.CategoryId))]
    public Category Category { get; set; } = null!;

    [ForeignKey(nameof(User.UserId))]
    [InverseProperty(nameof(User.Projects))]
    public virtual User? Owner { get; set; }

    public DateTimeOffset? StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    [StringLength(255)]
    public string? ExternalReference { get; set; }

    public virtual ICollection<TaskItem> TaskItems { get; set; } = [];

    public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

    public DateTimeOffset DateLastModified { get; set; } = DateTimeOffset.Now;

    public Guid SyncId { get; set; }

    public static IEnumerable<Project> GetActiveProjects()
    {
        using var context = new TaskTamerContext();

        return context.Projects
            .Where(p => p.Status != "Inactive")
            .Include(p => p.Category)
            .ToArray();
    }
}
