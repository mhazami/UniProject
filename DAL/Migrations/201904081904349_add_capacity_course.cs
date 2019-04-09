namespace UniProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_capacity_course : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Capacity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Capacity");
        }
    }
}
