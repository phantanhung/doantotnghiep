namespace FoodOrderSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatememberpoint : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "AccumulatedPoints", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "AccumulatedPoints");
        }
    }
}
