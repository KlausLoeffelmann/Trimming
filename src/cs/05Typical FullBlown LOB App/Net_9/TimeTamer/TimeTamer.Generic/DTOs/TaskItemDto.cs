using System;

namespace TaskTamer.DataLayer.Models
{
    public class TaskItemDto
    {
        public Guid TaskItemId { get; set; }
        public Guid? ProjectId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Guid? AssignedToUserId { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Status { get; set; }
        public string? ExternalReference { get; set; }
    }
}
