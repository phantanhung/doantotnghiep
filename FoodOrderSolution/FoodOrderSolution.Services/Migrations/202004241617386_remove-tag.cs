namespace FoodOrderSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removetag : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ProductTags");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Tag = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
