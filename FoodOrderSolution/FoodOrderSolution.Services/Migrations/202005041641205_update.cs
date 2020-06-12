namespace FoodOrderSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promotions", "Vendor", c => c.Long(nullable: false));
            AddColumn("dbo.Promotions", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Promotions", "Status");
            DropColumn("dbo.Promotions", "Vendor");
        }
    }
}
