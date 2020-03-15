namespace MonashLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Engagement
    {
        public int id { get; set; }

        public int TAUnit_id { get; set; }

        [Required]
        [StringLength(128)]
        public string teachingAssistant_id { get; set; }

        public virtual TeachingAssistant TeachingAssistant { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
