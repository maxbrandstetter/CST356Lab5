namespace Lab_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 32),
                        LastName = c.String(nullable: false, maxLength: 32),
                        EmailAddress = c.String(nullable: false, maxLength: 64),
                        NumberOfSiblings = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GroupId);
            
            CreateTable(
                "dbo.GroupUsers",
                c => new
                    {
                        Group_GroupId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_GroupId, t.User_UserId })
                .ForeignKey("dbo.Groups", t => t.Group_GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Group_GroupId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.GroupUsers", "Group_GroupId", "dbo.Groups");
            DropIndex("dbo.GroupUsers", new[] { "User_UserId" });
            DropIndex("dbo.GroupUsers", new[] { "Group_GroupId" });
            DropTable("dbo.GroupUsers");
            DropTable("dbo.Groups");
            DropTable("dbo.Users");
        }
    }
}
