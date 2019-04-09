namespace UniProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix_db : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "BirthDate");
            DropColumn("dbo.Users", "NationalCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "NationalCode", c => c.String(nullable: false, maxLength: 10));
            AddColumn("dbo.Users", "BirthDate", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
