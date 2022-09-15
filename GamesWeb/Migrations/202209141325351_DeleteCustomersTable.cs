namespace GamesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class DeleteCustomersTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Customers");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false, maxLength: 255),
                    LastName = c.String(nullable: false, maxLength: 255),
                    IsSubscribedToNewsletter = c.Boolean(nullable: false),
                    MembershipTypeId = c.Byte(nullable: false),
                    Birthdate = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);
        }
    }
}