namespace GamesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLastModifiedPropertyToGameClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "LastModified", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "LastModified");
        }
    }
}
