namespace TaskTamer.DTOs;

public class ProjectDto
{
    public Guid ProjectId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Status { get; set; }
    public string? ExternalReference { get; set; }
}
