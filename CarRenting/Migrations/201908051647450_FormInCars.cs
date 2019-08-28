namespace CarRenting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormInCars : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cars", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Cars", new[] { "Genre_Id" });
            AlterColumn("dbo.Cars", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Cars", "Genre_Id");
            AddForeignKey("dbo.Cars", "Genre_Id", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Cars", new[] { "Genre_Id" });
            AlterColumn("dbo.Cars", "Genre_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Cars", "Genre_Id");
            AddForeignKey("dbo.Cars", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
