namespace GamesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCustomersTableAndMigratePropertiesToIdentityModels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.AspNetUsers", "IsSubscribedToNewsletter", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "MembershipTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.AspNetUsers", "Birthdate", c => c.DateTime());
            CreateIndex("dbo.AspNetUsers", "MembershipTypeId");

        }
        
        public override void Down()
        {

            DropIndex("dbo.AspNetUsers", new[] { "MembershipTypeId" });
            DropColumn("dbo.AspNetUsers", "Birthdate");
            DropColumn("dbo.AspNetUsers", "MembershipTypeId");
            DropColumn("dbo.AspNetUsers", "IsSubscribedToNewsletter");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
    }
}
