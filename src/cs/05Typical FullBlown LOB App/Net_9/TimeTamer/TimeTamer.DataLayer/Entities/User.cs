using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTamer.DataLayer.Models;

public partial class User
{
    [Key]
    public Guid UserId { get; set; }

    [StringLength(255)]
    public string Username { get; set; } = null!;

    [StringLength(255)]
    public string? FirstName { get; set; }

    [StringLength(255)]
    public string? LastName { get; set; }

    [StringLength(255)]
    public string Email { get; set; } = null!;

    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    [StringLength(50)]
    public string? Role { get; set; }

    public DateTimeOffset DateCreated { get; set; }

    public DateTimeOffset DateLastModified { get; set; }

    public Guid SyncId { get; set; }

    [InverseProperty(nameof(Project.Owner))]
    public virtual ICollection<Project> Projects { get; set; } = [];

    [InverseProperty(nameof(TaskItem.Owner))]
    public virtual ICollection<TaskItem> TaskItems { get; set; } = [];

    public static User GetCurrentUser()
    {
        TaskTamerContext context = new();
        return context.Users.First();
    }
}
