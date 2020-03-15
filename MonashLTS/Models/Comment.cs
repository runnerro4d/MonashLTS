namespace MonashLTS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        public string CommentText { get; set; }

        [Required]
        public string Action { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? ClosedDate { get; set; }

        [StringLength(128)]
        public string AssignedCM_id { get; set; }

        [StringLength(128)]
        public string CurrentCase_id { get; set; }

        public virtual CaseManager CaseManager { get; set; }

        public virtual Case Case { get; set; }
    }
}
