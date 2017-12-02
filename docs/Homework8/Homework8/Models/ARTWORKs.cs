namespace Homework8.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ARTWORK")]
    public partial class ARTWORKs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ARTWORKs()
        {
            CLASSIFICATIONs = new HashSet<CLASSIFICATIONs>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string TITLE { get; set; }

        public int? ARTIST { get; set; }

        public virtual ARTISTs ARTIST1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CLASSIFICATIONs> CLASSIFICATIONs { get; set; }
    }
}
