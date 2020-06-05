namespace FoodOrderSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addreplyfeedback : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VendorReplys",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Feedback = c.Long(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.VendorReplys");
        }
    }
}
