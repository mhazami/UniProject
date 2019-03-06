namespace UniProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Student : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "FileId", "dbo.Files");
            DropIndex("dbo.Users", new[] { "FileId" });
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NationalCode = c.String(nullable: false, maxLength: 10),
                        BirthDate = c.String(nullable: false, maxLength: 10),
                        StudentNumber = c.String(nullable: false, maxLength: 9),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        CellPhone = c.String(nullable: false, maxLength: 11),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Username", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            DropColumn("dbo.Users", "StudentNumber");
            DropColumn("dbo.Users", "FileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "FileId", c => c.Guid(nullable: false));
            AddColumn("dbo.Users", "StudentNumber", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "Username");
            DropTable("dbo.Students");
            CreateIndex("dbo.Users", "FileId");
            AddForeignKey("dbo.Users", "FileId", "dbo.Files", "FileId", cascadeDelete: true);
        }
    }
}
