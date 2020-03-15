namespace MonashLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TeachingAssistant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TeachingAssistant()
        {
            Cases = new HashSet<Case>();
            Engagements = new HashSet<Engagement>();
        }

        public string id { get; set; }

        [Required]
        public string FirstNameTA { get; set; }

        [Required]
        public string LastNameTA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Case> Cases { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Engagement> Engagements { get; set; }
    }

    [MetadataType(typeof(TAMetadata))]
    public partial class TeachingAssistant
    {
        [Display(Name = "TA Name")]
        public string FullNameTA
        {
            get
            {
                return (FirstNameTA + " " + LastNameTA).Trim();
            }
        }

        public class TAMetadata
        {
        }
    }

}
