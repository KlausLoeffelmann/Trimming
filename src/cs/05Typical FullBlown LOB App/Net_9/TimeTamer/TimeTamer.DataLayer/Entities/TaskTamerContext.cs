using Microsoft.EntityFrameworkCore;

namespace TaskTamer.DataLayer.Models;

public partial class TaskTamerContext : DbContext
{
    public TaskTamerContext()
    {
    }

    public TaskTamerContext(DbContextOptions<TaskTamerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<TaskItem> TaskItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=TaskTamer;Integrated Security=True;");
}
