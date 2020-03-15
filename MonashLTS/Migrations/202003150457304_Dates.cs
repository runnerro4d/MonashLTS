namespace MonashLTS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CaseManagers",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        FirstNameCM = c.String(nullable: false),
                        LastNameCM = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        CaseManager_id = c.String(maxLength: 128),
                        Student_id = c.Int(),
                        TeachingAssistant_id = c.String(maxLength: 128),
                        Unit_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Students", t => t.Student_id)
                .ForeignKey("dbo.Units", t => t.Unit_id)
                .ForeignKey("dbo.TeachingAssistants", t => t.TeachingAssistant_id)
                .ForeignKey("dbo.CaseManagers", t => t.CaseManager_id)
                .Index(t => t.CaseManager_id)
                .Index(t => t.Student_id)
                .Index(t => t.TeachingAssistant_id)
                .Index(t => t.Unit_id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CreatedDate = c.DateTime(nullable: false),
                        CommentText = c.String(),
                        Action = c.String(nullable: false),
                        ClosedDate = c.DateTime(),
                        AssignedCM_id = c.String(maxLength: 128),
                        CurrentCase_id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Cases", t => t.CurrentCase_id)
                .ForeignKey("dbo.CaseManagers", t => t.AssignedCM_id)
                .Index(t => t.AssignedCM_id)
                .Index(t => t.CurrentCase_id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CourseTitle = c.String(nullable: false),
                        CourseAttendType = c.String(nullable: false),
                        Alias = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Enrolments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UnitAttemptStat = c.String(nullable: false),
                        student_id = c.Int(nullable: false),
                        StuUnit_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Units", t => t.StuUnit_id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.student_id, cascadeDelete: true)
                .Index(t => t.student_id)
                .Index(t => t.StuUnit_id);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UnitCode = c.String(nullable: false),
                        UnitVer = c.String(),
                        UnitTitle = c.String(),
                        UnitClass = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Engagements",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TAUnit_id = c.Int(nullable: false),
                        teachingAssistant_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TeachingAssistants", t => t.teachingAssistant_id, cascadeDelete: true)
                .ForeignKey("dbo.Units", t => t.TAUnit_id, cascadeDelete: true)
                .Index(t => t.TAUnit_id)
                .Index(t => t.teachingAssistant_id);
            
            CreateTable(
                "dbo.TeachingAssistants",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        FirstNameTA = c.String(nullable: false),
                        LastNameTA = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "AssignedCM_id", "dbo.CaseManagers");
            DropForeignKey("dbo.Cases", "CaseManager_id", "dbo.CaseManagers");
            DropForeignKey("dbo.Enrolments", "student_id", "dbo.Students");
            DropForeignKey("dbo.Enrolments", "StuUnit_id", "dbo.Units");
            DropForeignKey("dbo.Engagements", "TAUnit_id", "dbo.Units");
            DropForeignKey("dbo.Engagements", "teachingAssistant_id", "dbo.TeachingAssistants");
            DropForeignKey("dbo.Cases", "TeachingAssistant_id", "dbo.TeachingAssistants");
            DropForeignKey("dbo.Cases", "Unit_id", "dbo.Units");
            DropForeignKey("dbo.Cases", "Student_id", "dbo.Students");
            DropForeignKey("dbo.Comments", "CurrentCase_id", "dbo.Cases");
            DropIndex("dbo.Engagements", new[] { "teachingAssistant_id" });
            DropIndex("dbo.Engagements", new[] { "TAUnit_id" });
            DropIndex("dbo.Enrolments", new[] { "StuUnit_id" });
            DropIndex("dbo.Enrolments", new[] { "student_id" });
            DropIndex("dbo.Comments", new[] { "CurrentCase_id" });
            DropIndex("dbo.Comments", new[] { "AssignedCM_id" });
            DropIndex("dbo.Cases", new[] { "Unit_id" });
            DropIndex("dbo.Cases", new[] { "TeachingAssistant_id" });
            DropIndex("dbo.Cases", new[] { "Student_id" });
            DropIndex("dbo.Cases", new[] { "CaseManager_id" });
            DropTable("dbo.TeachingAssistants");
            DropTable("dbo.Engagements");
            DropTable("dbo.Units");
            DropTable("dbo.Enrolments");
            DropTable("dbo.Students");
            DropTable("dbo.Comments");
            DropTable("dbo.Cases");
            DropTable("dbo.CaseManagers");
        }
    }
}
