namespace BookstoreProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Genre", c => c.String(nullable: false, maxLength: 154));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Genre");
        }
    }
}
