namespace Homework9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLASSIFICATION")]
    public partial class CLASSIFICATION
    {
        public int ID { get; set; }

        public int ARTWORK { get; set; }

        public int GENRE { get; set; }

        public virtual ARTWORK ARTWORK1 { get; set; }

        public virtual GENRE GENRE1 { get; set; }
    }
}
