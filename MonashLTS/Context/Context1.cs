using MonashLTS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MonashLTS.Context
{
    public class Context1 : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<TeachingAssistant> TeachingAssistants { get; set; }

        public DbSet<CaseManager> CaseManagers { get; set; }

        public DbSet<Case> Cases { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Engagement> Engagements { get; set; }

        public DbSet<Enrolment> Enrolments { get; set; }
    }
}