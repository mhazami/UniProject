namespace UniProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_DB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Guid(nullable: false),
                        Context = c.Binary(),
                        ContextType = c.String(nullable: false, maxLength: 10),
                        Title = c.String(nullable: false, maxLength: 50),
                        FileSize = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.String(nullable: false, maxLength: 10),
                        NationalCode = c.String(nullable: false, maxLength: 10),
                        StudentNumber = c.String(nullable: false, maxLength: 50),
                        FileId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Files", t => t.FileId, cascadeDelete: true)
                .Index(t => t.FileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "FileId", "dbo.Files");
            DropIndex("dbo.Users", new[] { "FileId" });
            DropTable("dbo.Users");
            DropTable("dbo.Files");
        }
    }
}
