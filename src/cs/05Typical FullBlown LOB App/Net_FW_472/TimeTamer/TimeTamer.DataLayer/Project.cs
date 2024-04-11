namespace TimeTamer.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Project()
        {
            Tasks = new HashSet<Task>();
        }

        public Guid ProjectId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid? OwnerId { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(255)]
        public string ExternalReference { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
