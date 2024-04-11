namespace TimeTamer.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        public Guid CategoryId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
