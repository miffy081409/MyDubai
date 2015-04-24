namespace MyDubai.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusID = c.String(nullable: false, maxLength: 128),
                        Username = c.String(maxLength: 128),
                        StatusPosted = c.String(),
                        LastLikesCount = c.Int(nullable: false),
                        LastShareCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatusID)
                .ForeignKey("dbo.UserProfiles", t => t.Username)
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Status", "Username", "dbo.UserProfiles");
            DropIndex("dbo.Status", new[] { "Username" });
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Status");
        }
    }
}
