namespace TaskTamer.DTOs;

public class TaskItemDto
{
    public Guid TaskItemId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public CategoryDto Category { get; set; } = null!;
    public ProjectDto Project { get; set; } = null!;
    public UserDto User { get; set; } = null!;
    public DateTimeOffset? DueDate { get; set; }
    public TaskItemStatus TaskStatus { get; set; }
    public string? ExternalReference { get; set; }
}
