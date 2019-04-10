namespace UniProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix_coursestudent : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.CourseStudents", "CourseId");
            CreateIndex("dbo.CourseStudents", "StudentId");
            AddForeignKey("dbo.CourseStudents", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CourseStudents", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseStudents", "StudentId", "dbo.Students");
            DropForeignKey("dbo.CourseStudents", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseStudents", new[] { "StudentId" });
            DropIndex("dbo.CourseStudents", new[] { "CourseId" });
        }
    }
}
