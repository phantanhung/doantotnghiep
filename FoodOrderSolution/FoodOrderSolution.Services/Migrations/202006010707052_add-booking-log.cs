namespace FoodOrderSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbookinglog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingLogs",
                c => new
                    {
                        TransactionID = c.String(nullable: false, maxLength: 128),
                        Step = c.Int(nullable: false),
                        Name = c.String(),
                        Member = c.Int(nullable: false),
                        PostJson = c.String(),
                        PartnerResult = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.TransactionID, t.Step });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookingLogs");
        }
    }
}
