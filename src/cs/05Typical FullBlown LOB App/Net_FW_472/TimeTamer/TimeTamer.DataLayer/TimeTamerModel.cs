using System.Data.Entity;

namespace TimeTamer.DataLayer
{
    public partial class TimeTamerModel : DbContext
    {
        public TimeTamerModel()
            : base("name=TimeTamer")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.Projects)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.OwnerId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tasks)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.AssignedToUserId);
        }
    }
}
