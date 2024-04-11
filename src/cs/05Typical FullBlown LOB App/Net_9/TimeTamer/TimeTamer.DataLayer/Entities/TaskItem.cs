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

    public List<TaskItem> GetDemoTasks(User user, List<Project> projects)
    {
        List<TaskItem> demoTasks = new List<TaskItem>();

        // Add 50 demo tasks with creative and funny descriptions
        demoTasks.Add(new TaskItem
        {
            TaskItemId = Guid.NewGuid(),
            Name = "Fix the Flux Capacitor",
            Description = "The Flux Capacitor in the time machine is malfunctioning. Fix it before the next time travel adventure!",
            AssignedToUserId = user.UserId,
            DueDate = DateTime.Now.AddDays(3),
            Status = "In Progress"
        });

        demoTasks.Add(new TaskItem
        {
            TaskItemId = Guid.NewGuid(),
            Name = "Unicorn Wrangling",
            Description = "Capture and tame a wild unicorn. Remember to bring a bag of rainbow dust!",
            AssignedToUserId = user.UserId,
            DueDate = DateTime.Now.AddDays(5),
            Status = "Not Started"
        });

        // Add 10 additional demo tasks with funny descriptions
        demoTasks.Add(new TaskItem
        {
            TaskItemId = Guid.NewGuid(),
            Name = "Solve the Mystery of the Missing Socks",
            Description = "Investigate the disappearance of socks from the laundry. Beware of the sock-eating monster!",
            AssignedToUserId = user.UserId,
            DueDate = DateTime.Now.AddDays(2),
            Status = "In Progress"
        });

        demoTasks.Add(new TaskItem
        {
            TaskItemId = Guid.NewGuid(),
            Name = "Create a Recipe for Invisible Ink",
            Description = "Develop a secret recipe for invisible ink. Perfect for top-secret messages!",
            AssignedToUserId = user.UserId,
            DueDate = DateTime.Now.AddDays(4),
            Status = "Not Started"
        });

        demoTasks.Add(new TaskItem
        {
            TaskItemId = Guid.NewGuid(),
            Name = "Build a Pillow Fort",
            Description = "Construct an epic pillow fort. Make sure it has multiple rooms and a secret entrance!",
            AssignedToUserId = user.UserId,
            DueDate = DateTime.Now.AddDays(1),
            Status = "In Progress"
        });

        demoTasks.Add(new TaskItem
        {
            TaskItemId = Guid.NewGuid(),
            Name = "Train a Pet Rock",
            Description = "Teach your pet rock some cool tricks. Start with sit, stay, and roll over!",
            AssignedToUserId = user.UserId,
            DueDate = DateTime.Now.AddDays(3),
            Status = "Not Started"
        });

        demoTasks.Add(new TaskItem
        {
            TaskItemId = Guid.NewGuid(),
            Name = "Create a Time-Traveling Robot",
            Description = "Build a robot that can travel through time. Don't forget to program it with good manners!",
            AssignedToUserId = user.UserId,
            DueDate = DateTime.Now.AddDays(5),
            Status = "Not Started"
        });

        demoTasks.Add(new TaskItem
        {
            TaskItemId = Guid.NewGuid(),
            Name = "Write a Love Letter to a Pizza",
            Description = "Compose a heartfelt love letter to your favorite pizza. Express your cheesy feelings!",
            AssignedToUserId = user.UserId,
            DueDate = DateTime.Now.AddDays(2),
            Status = "In Progress"
        });

        demoTasks.Add(new TaskItem
        {
            TaskItemId = Guid.NewGuid(),
            Name = "Become a Master of Puzzles",
            Description = "Solve 1000 puzzles of various types. Challenge your brain and unlock the puzzle master achievement!",
            AssignedToUserId = user.UserId,
            DueDate = DateTime.Now.AddDays(7),
            Status = "Not Started"
        });

        demoTasks.Add(new TaskItem
        {
            TaskItemId = Guid.NewGuid(),
            Name = "Learn to Speak Dolphin",
            Description = "Study dolphin language and become fluent in communicating with these intelligent creatures!",
            AssignedToUserId = user.UserId,
            DueDate = DateTime.Now.AddDays(4),
            Status = "In Progress"
        });

        demoTasks.Add(new TaskItem
        {
            TaskItemId = Guid.NewGuid(),
            Name = "Conquer Mount Everest",
            Description = "Embark on a journey to conquer the highest peak in the world. Don't forget your climbing gear!",
            AssignedToUserId = user.UserId,
            DueDate = DateTime.Now.AddDays(10),
            Status = "Not Started"
        });

        return demoTasks;
    }
}
