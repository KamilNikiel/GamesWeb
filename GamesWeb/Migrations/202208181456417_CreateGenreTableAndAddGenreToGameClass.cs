namespace GamesWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGenreTableAndAddGenreToGameClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Games", "Genre_Id", c => c.Byte());
            CreateIndex("dbo.Games", "Genre_Id");
            AddForeignKey("dbo.Games", "Genre_Id", "dbo.Genres", "Id");
            DropColumn("dbo.Games", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "Genre", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.Games", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Games", new[] { "Genre_Id" });
            DropColumn("dbo.Games", "Genre_Id");
            DropTable("dbo.Genres");
        }
    }
}
