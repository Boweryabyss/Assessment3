namespace BookstoreProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookproperties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 154),
                        Author = c.String(nullable: false, maxLength: 154),
                        Price = c.Double(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
        }
    }
}
