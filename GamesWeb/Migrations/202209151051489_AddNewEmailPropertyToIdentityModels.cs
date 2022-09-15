namespace GamesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewEmailPropertyToIdentityModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NewEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NewEmail");
        }
    }
}
