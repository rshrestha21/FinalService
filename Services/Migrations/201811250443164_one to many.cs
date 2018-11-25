namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onetomany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Services", "servicetype_ServicetypeId", "dbo.Servicetypes");
            DropIndex("dbo.Services", new[] { "servicetype_ServicetypeId" });
            RenameColumn(table: "dbo.Services", name: "servicetype_ServicetypeId", newName: "ServicetypeId");
            AlterColumn("dbo.Services", "ServicetypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Services", "ServicetypeId");
            AddForeignKey("dbo.Services", "ServicetypeId", "dbo.Servicetypes", "ServicetypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "ServicetypeId", "dbo.Servicetypes");
            DropIndex("dbo.Services", new[] { "ServicetypeId" });
            AlterColumn("dbo.Services", "ServicetypeId", c => c.Int());
            RenameColumn(table: "dbo.Services", name: "ServicetypeId", newName: "servicetype_ServicetypeId");
            CreateIndex("dbo.Services", "servicetype_ServicetypeId");
            AddForeignKey("dbo.Services", "servicetype_ServicetypeId", "dbo.Servicetypes", "ServicetypeId");
        }
    }
}
