namespace Assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Car
    {
        [Key]
        public int Cars { get; set; }

        [Required]
        [StringLength(10)]
        public string Car1 { get; set; }

        [Required]
        [StringLength(10)]
        public string Car2 { get; set; }

        [Required]
        [StringLength(10)]
        public string Car3 { get; set; }
    }
}
