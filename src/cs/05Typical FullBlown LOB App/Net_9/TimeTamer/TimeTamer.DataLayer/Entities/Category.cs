using System.ComponentModel.DataAnnotations;

namespace TimeTamer.DataLayer.Models;

public partial class Category
{
    [Key]
    public Guid CategoryId { get; set; }

    [StringLength(255)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateLastModified { get; set; }
    public Guid SyncId { get; set; }
}
