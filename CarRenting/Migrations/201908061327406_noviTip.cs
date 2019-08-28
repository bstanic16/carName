namespace CarRenting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class noviTip : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Cars", new[] { "Genre_Id" });
            DropColumn("dbo.Cars", "GenreId");
            RenameColumn(table: "dbo.Cars", name: "Genre_Id", newName: "GenreId");
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Cars", "GenreId", c => c.Byte(nullable: true));
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Cars", "GenreId");
            AddForeignKey("dbo.Cars", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "GenreId", "dbo.Genres");
            DropIndex("dbo.Cars", new[] { "GenreId" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Genres", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Cars", "GenreId", c => c.Int());
            AddPrimaryKey("dbo.Genres", "Id");
            RenameColumn(table: "dbo.Cars", name: "GenreId", newName: "Genre_Id");
            AddColumn("dbo.Cars", "GenreId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Cars", "Genre_Id");
            AddForeignKey("dbo.Cars", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
