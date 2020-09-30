namespace CodeFirst_WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDesignModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instructors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 50),
                        FirstMidName = c.String(),
                        HireDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.InstructorCourses",
                c => new
                    {
                        Instructor_ID = c.Int(nullable: false),
                        Course_CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Instructor_ID, t.Course_CourseID })
                .ForeignKey("dbo.Instructors", t => t.Instructor_ID, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Course_CourseID, cascadeDelete: true)
                .Index(t => t.Instructor_ID)
                .Index(t => t.Course_CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InstructorCourses", "Course_CourseID", "dbo.Courses");
            DropForeignKey("dbo.InstructorCourses", "Instructor_ID", "dbo.Instructors");
            DropIndex("dbo.InstructorCourses", new[] { "Course_CourseID" });
            DropIndex("dbo.InstructorCourses", new[] { "Instructor_ID" });
            DropTable("dbo.InstructorCourses");
            DropTable("dbo.Instructors");
        }
    }
}
