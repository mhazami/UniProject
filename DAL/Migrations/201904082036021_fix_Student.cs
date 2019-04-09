namespace UniProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix_Student : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Username", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.Students", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Password");
            DropColumn("dbo.Students", "Username");
        }
    }
}
