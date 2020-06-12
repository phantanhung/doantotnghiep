namespace FoodOrderSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorderreceipt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Receipt", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Receipt");
        }
    }
}
