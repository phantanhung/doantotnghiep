namespace FoodOrderSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatevoucherpromotion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vouchers", "Promotion", c => c.Long(nullable: false));
            DropColumn("dbo.Promotions", "Voucher");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Promotions", "Voucher", c => c.Int(nullable: false));
            DropColumn("dbo.Vouchers", "Promotion");
        }
    }
}
