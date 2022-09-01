namespace GamesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Action RPG')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'FPS')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'RPG')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Simulation')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (7, 'Strategy')");
        }
        
        public override void Down()
        {
        }
    }
}
