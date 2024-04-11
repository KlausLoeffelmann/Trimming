namespace TimeTamer.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Task
    {
        public Guid TaskId { get; set; }

        public Guid? ProjectId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? AssignedToUserId { get; set; }

        public DateTime? DueDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(255)]
        public string ExternalReference { get; set; }

        public virtual Project Project { get; set; }

        public virtual User User { get; set; }
    }
}
