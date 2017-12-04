namespace Homework9.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ARTIST")]
    public partial class ARTIST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ARTIST()
        {
            ARTWORKs = new HashSet<ARTWORK>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string NAME { get; set; }

        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [Required]
        [StringLength(255)]
        public string BIRTHCITY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ARTWORK> ARTWORKs { get; set; }
    }
}
