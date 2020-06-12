namespace FoodOrderSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatevoucherfiled : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vouchers", "Product", c => c.String());
            DropColumn("dbo.Vouchers", "Produt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vouchers", "Produt", c => c.String());
            DropColumn("dbo.Vouchers", "Product");
        }
    }
}
