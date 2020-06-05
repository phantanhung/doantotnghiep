namespace FoodOrderSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatepromotioncode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Promotions", "Code", c => c.String(maxLength: 6));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Promotions", "Code");
        }
    }
}
