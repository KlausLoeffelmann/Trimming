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

public static class CategoryDataGenerator
{
    public static void GenerateCategories(TimeTamerContext context)
    {
        string[] categoryNames = new string[]
        {
            "Development",
            "Testing",
            "Documentation",
            "Bug Fixing",
            "Feature Implementation",
            "Code Review",
            "Deployment",
            "Database Management",
            "UI/UX Design",
            "Project Management"
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
