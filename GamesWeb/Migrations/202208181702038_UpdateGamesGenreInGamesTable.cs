namespace GamesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGamesGenreInGamesTable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Games SET GenreId = 2 WHERE Id = 1");
            Sql("UPDATE Games SET GenreId = 5 WHERE Id = 2");
            Sql("UPDATE Games SET GenreId = 5 WHERE Id = 3");
        }
        
        public override void Down()
        {
        }
    }
}
