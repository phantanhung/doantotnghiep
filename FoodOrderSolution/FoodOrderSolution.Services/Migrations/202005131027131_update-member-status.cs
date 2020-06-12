namespace FoodOrderSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatememberstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Members", "Status");
        }
    }
}
