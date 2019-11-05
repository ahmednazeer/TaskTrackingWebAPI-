namespace Web_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addProjectTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Tasks", "AssigneeName", c => c.String(nullable: false));
            AddColumn("dbo.Tasks", "ProjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "DeliveryDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Tasks", "ProjectId");
            AddForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects", "ID", cascadeDelete: true);
            DropColumn("dbo.Tasks", "Assignee");
            DropColumn("dbo.Tasks", "Project");
            DropColumn("dbo.Tasks", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "Project", c => c.String(nullable: false));
            AddColumn("dbo.Tasks", "Assignee", c => c.String(nullable: false));
            DropForeignKey("dbo.Tasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Tasks", new[] { "ProjectId" });
            DropColumn("dbo.Tasks", "DeliveryDate");
            DropColumn("dbo.Tasks", "ProjectId");
            DropColumn("dbo.Tasks", "AssigneeName");
            DropTable("dbo.Projects");
        }
    }
}
