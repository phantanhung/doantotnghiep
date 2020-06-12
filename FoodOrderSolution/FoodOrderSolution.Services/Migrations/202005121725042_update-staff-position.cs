namespace FoodOrderSolution.Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatestaffposition : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Staffs", "Position");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Staffs", "Position", c => c.String());
        }
    }
}
