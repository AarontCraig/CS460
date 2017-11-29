namespace Homework7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Query
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string SearchQuery { get; set; }

        public DateTime SearchDate { get; set; }

        [StringLength(255)]
        public string SearchIP { get; set; }

        [StringLength(255)]
        public string SearchBrowser { get; set; }
    }
}
