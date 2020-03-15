namespace MonashLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Enrolment
    {
        public int id { get; set; }

        [Required]
        public string UnitAttemptStat { get; set; }

        public int student_id { get; set; }

        public int StuUnit_id { get; set; }

        public virtual Student Student { get; set; }

        public virtual Unit Unit { get; set; }
    }
}
