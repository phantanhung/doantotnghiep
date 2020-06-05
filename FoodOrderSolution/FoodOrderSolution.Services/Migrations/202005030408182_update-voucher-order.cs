namespace FoodOrderSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatevoucherorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Vendor", c => c.Long(nullable: false));
            AddColumn("dbo.Vouchers", "Vendor", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vouchers", "Vendor");
            DropColumn("dbo.Orders", "Vendor");
        }
    }
}
