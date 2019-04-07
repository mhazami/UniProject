namespace UniProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix_course : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "ClassTime", c => c.String());
            AddColumn("dbo.Courses", "Status", c => c.Byte(nullable: false));
            DropColumn("dbo.Courses", "ClassDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "ClassDay", c => c.String());
            DropColumn("dbo.Courses", "Status");
            DropColumn("dbo.Courses", "ClassTime");
        }
    }
}
