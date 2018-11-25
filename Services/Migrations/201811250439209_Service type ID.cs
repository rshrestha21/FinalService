namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ServicetypeID : DbMigration
    {
        public override void Up()
        {
            
            DropForeignKey("dbo.Services", "servicetype_Id", "dbo.Servicetypes");
            RenameColumn(table: "dbo.Services", name: "servicetype_Id", newName: "servicetype_ServicetypeId");
            RenameIndex(table: "dbo.Services", name: "IX_servicetype_Id", newName: "IX_servicetype_ServicetypeId");
            DropPrimaryKey("dbo.Servicetypes");
            DropColumn("dbo.Servicetypes", "Id");
            AddColumn("dbo.Servicetypes", "ServicetypeId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Services", "Name", c => c.String(maxLength: 10));
            AlterColumn("dbo.Services", "Desription", c => c.String(maxLength: 3000));
            AddPrimaryKey("dbo.Servicetypes", "ServicetypeId");
            AddForeignKey("dbo.Services", "servicetype_ServicetypeId", "dbo.Servicetypes", "ServicetypeId");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Servicetypes", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Services", "servicetype_ServicetypeId", "dbo.Servicetypes");
            DropPrimaryKey("dbo.Servicetypes");
            AlterColumn("dbo.Services", "Desription", c => c.String());
            AlterColumn("dbo.Services", "Name", c => c.String());
            DropColumn("dbo.Servicetypes", "ServicetypeId");
            AddPrimaryKey("dbo.Servicetypes", "Id");
            RenameIndex(table: "dbo.Services", name: "IX_servicetype_ServicetypeId", newName: "IX_servicetype_Id");
            RenameColumn(table: "dbo.Services", name: "servicetype_ServicetypeId", newName: "servicetype_Id");
            AddForeignKey("dbo.Services", "servicetype_Id", "dbo.Servicetypes", "Id");
        }
    }
}
