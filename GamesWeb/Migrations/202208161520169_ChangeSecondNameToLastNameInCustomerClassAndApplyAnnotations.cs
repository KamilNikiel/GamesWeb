namespace GamesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSecondNameToLastNameInCustomerClassAndApplyAnnotations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Customers", "SecondName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "SecondName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
            DropColumn("dbo.Customers", "LastName");
        }
    }
}
