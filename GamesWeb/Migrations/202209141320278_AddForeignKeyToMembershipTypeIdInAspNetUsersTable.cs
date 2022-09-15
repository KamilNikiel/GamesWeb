namespace GamesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddForeignKeyToMembershipTypeIdInAspNetUsersTable : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.AspNetUsers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "MembershipTypeId", "dbo.MembershipTypes");
        }
    }
}

