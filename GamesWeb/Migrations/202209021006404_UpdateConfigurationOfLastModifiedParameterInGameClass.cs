namespace GamesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateConfigurationOfLastModifiedParameterInGameClass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Games", "LastModified", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "LastModified", c => c.DateTime(nullable: false));
        }
    }
}
