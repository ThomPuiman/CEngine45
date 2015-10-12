namespace CEngine45.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Body = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        CreatedBy_ID = c.Int(),
                        Topic_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserProfiles", t => t.CreatedBy_ID)
                .ForeignKey("dbo.Topics", t => t.Topic_ID)
                .Index(t => t.CreatedBy_ID)
                .Index(t => t.Topic_ID);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 45),
                        EmailAddress = c.String(),
                        MemberSince = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(nullable: false),
                        Category_ID = c.Int(),
                        CreatedBy_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .ForeignKey("dbo.UserProfiles", t => t.CreatedBy_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.CreatedBy_ID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "Topic_ID", "dbo.Topics");
            DropForeignKey("dbo.Topics", "CreatedBy_ID", "dbo.UserProfiles");
            DropForeignKey("dbo.Topics", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.Posts", "CreatedBy_ID", "dbo.UserProfiles");
            DropIndex("dbo.Topics", new[] { "CreatedBy_ID" });
            DropIndex("dbo.Topics", new[] { "Category_ID" });
            DropIndex("dbo.Posts", new[] { "Topic_ID" });
            DropIndex("dbo.Posts", new[] { "CreatedBy_ID" });
            DropTable("dbo.Categories");
            DropTable("dbo.Topics");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Posts");
        }
    }
}
