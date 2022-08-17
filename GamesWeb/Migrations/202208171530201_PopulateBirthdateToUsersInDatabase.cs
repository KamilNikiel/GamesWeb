namespace GamesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBirthdateToUsersInDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate = '1997-11-11' WHERE Id = 1;");
            Sql("UPDATE Customers SET Birthdate = '1998-04-23' WHERE Id = 2;");
        }
        
        public override void Down()
        {
        }
    }
}
