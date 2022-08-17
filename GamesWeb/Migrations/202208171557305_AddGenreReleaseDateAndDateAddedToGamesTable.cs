namespace GamesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreReleaseDateAndDateAddedToGamesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Genre", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Games", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Games", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Games", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Games", "Name", c => c.String());
            DropColumn("dbo.Games", "DateAdded");
            DropColumn("dbo.Games", "ReleaseDate");
            DropColumn("dbo.Games", "Genre");
        }
    }
}
