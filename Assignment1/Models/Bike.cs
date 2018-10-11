namespace Assignment1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bike
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Bikes { get; set; }

        [Required]
        [StringLength(10)]
        public string Bike1 { get; set; }

        [Required]
        [StringLength(10)]
        public string Bike2 { get; set; }

        [Required]
        [StringLength(10)]
        public string Bike3 { get; set; }
    }
}
