using Microsoft.EntityFrameworkCore;

namespace TimeTamer.DataLayer.Models;

public partial class TimeTamerContext : DbContext
{
    public TimeTamerContext()
    {
    }

    public TimeTamerContext(DbContextOptions<TimeTamerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<TaskItem> TaskItems { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=TimeTamer;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A0BDF8D7B93");

            entity.Property(e => e.CategoryId).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Projects__761ABEF062EF0429");

            entity.Property(e => e.ProjectId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Owner).WithMany(p => p.Projects).HasConstraintName("FK__Projects__OwnerI__2B3F6F97");
        });

        modelBuilder.Entity<TaskItem>(entity =>
        {
            entity.HasKey(e => e.TaskItemId).HasName("PK__Tasks__7C6949B18B6BCC9F");

            entity.Property(e => e.TaskItemId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.AssignedToUser).WithMany(p => p.TaskItems).HasConstraintName("FK__Tasks__AssignedT__300424B4");

            entity.HasOne(d => d.Project).WithMany(p => p.TaskItems).HasConstraintName("FK__Tasks__ProjectId__2F10007B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C491516A0");

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
