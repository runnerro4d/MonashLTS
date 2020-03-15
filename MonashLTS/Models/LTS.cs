namespace MonashLTS.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LTS : DbContext
    {
        public LTS()
            : base("name=LTS1")
        {
        }

        public virtual DbSet<CaseManager> CaseManagers { get; set; }
        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Engagement> Engagements { get; set; }
        public virtual DbSet<Enrolment> Enrolments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<TeachingAssistant> TeachingAssistants { get; set; }
        public virtual DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaseManager>()
                .HasMany(e => e.Cases)
                .WithOptional(e => e.CaseManager)
                .HasForeignKey(e => e.CaseManager_id);

            modelBuilder.Entity<CaseManager>()
                .HasMany(e => e.Comments)
                .WithOptional(e => e.CaseManager)
                .HasForeignKey(e => e.AssignedCM_id);

            modelBuilder.Entity<Case>()
                .HasMany(e => e.Comments)
                .WithOptional(e => e.Case)
                .HasForeignKey(e => e.CurrentCase_id);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Cases)
                .WithOptional(e => e.Student)
                .HasForeignKey(e => e.Student_id);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Enrolments)
                .WithRequired(e => e.Student)
                .HasForeignKey(e => e.student_id);

            modelBuilder.Entity<TeachingAssistant>()
                .HasMany(e => e.Cases)
                .WithOptional(e => e.TeachingAssistant)
                .HasForeignKey(e => e.TeachingAssistant_id);

            modelBuilder.Entity<TeachingAssistant>()
                .HasMany(e => e.Engagements)
                .WithRequired(e => e.TeachingAssistant)
                .HasForeignKey(e => e.teachingAssistant_id);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.Cases)
                .WithOptional(e => e.Unit)
                .HasForeignKey(e => e.Unit_id);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.Engagements)
                .WithRequired(e => e.Unit)
                .HasForeignKey(e => e.TAUnit_id);

            modelBuilder.Entity<Unit>()
                .HasMany(e => e.Enrolments)
                .WithRequired(e => e.Unit)
                .HasForeignKey(e => e.StuUnit_id);
        }
    }
}
