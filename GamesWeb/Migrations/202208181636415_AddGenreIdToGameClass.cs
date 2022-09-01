namespace GamesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreIdToGameClass : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Games", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Games", name: "IX_Genre_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Games", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameColumn(table: "dbo.Games", name: "GenreId", newName: "Genre_Id");
        }
    }
}
