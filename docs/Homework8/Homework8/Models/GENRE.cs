namespace Homework8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GENRE")]
    public partial class GENRE
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string NAME { get; set; }
    }
}
