namespace FoodOrderSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatevoucherreceiver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vouchers", "Receiver", c => c.Int(nullable: false));
            AddColumn("dbo.Vouchers", "IsReceiver", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vouchers", "IsReceiver");
            DropColumn("dbo.Vouchers", "Receiver");
        }
    }
}
