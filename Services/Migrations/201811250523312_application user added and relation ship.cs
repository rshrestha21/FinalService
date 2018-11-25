namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class applicationuseraddedandrelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Services", "ApplicationUserID");
            AddForeignKey("dbo.Services", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Services", new[] { "ApplicationUserID" });
            DropColumn("dbo.Services", "ApplicationUserID");
        }
    }
}
