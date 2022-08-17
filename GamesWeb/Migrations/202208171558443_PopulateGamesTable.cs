namespace GamesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGamesTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Games ON");
            Sql("INSERT INTO Games (Id, Name, Genre, ReleaseDate, DateAdded) VALUES (1, 'The Witcher 3', 'Action RPG', '2015-05-19', '2022-08-17')");
            Sql("INSERT INTO Games (Id, Name, Genre, ReleaseDate, DateAdded) VALUES (2, 'Gothic', 'RPG', '2001-03-15', '2022-08-17')");
            Sql("INSERT INTO Games (Id, Name, Genre, ReleaseDate, DateAdded) VALUES (3, 'Gothic II', 'RPG', '2002-11-29', '2022-08-17')");
            Sql("SET IDENTITY_INSERT Games OFF");
        }

        public override void Down()
        {
        }
    }
}
