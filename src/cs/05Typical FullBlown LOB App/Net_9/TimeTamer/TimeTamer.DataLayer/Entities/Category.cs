using System.ComponentModel.DataAnnotations;

namespace TaskTamer.DataLayer.Models;

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

public partial class Category
{
    public static void EnsureSampleCategoriesData(TaskTamerContext context)
    {
        string[] categoryNames = new string[]
        {
            "Generic",
            "Chrono Conundrums",
            "Avian Ambitions",
            "Mystical Missions",
            "Technological Triumphs",
            "Whimsical Wonders"
        };

        foreach (string categoryName in categoryNames)
        {
            if (!context.Categories.Any(c => c.Name == categoryName))
            {
                Category category = new Category
                {
                    CategoryId = Guid.NewGuid(),
                    Name = categoryName,
                    Description = null,
                    DateCreated = DateTimeOffset.Now,
                    DateLastModified = DateTimeOffset.Now,
                    SyncId = Guid.NewGuid()
                };

                context.Categories.Add(category);
            }
        }

        context.SaveChanges();
    }
}
