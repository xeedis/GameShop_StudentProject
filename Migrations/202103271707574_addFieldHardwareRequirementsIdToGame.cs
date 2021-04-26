namespace GameShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFieldHardwareRequirementsIdToGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "HardwareRequirementsId", c => c.Int(nullable: false));
            DropColumn("dbo.HardwareRequirements", "GameId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HardwareRequirements", "GameId", c => c.Int(nullable: false));
            DropColumn("dbo.Game", "HardwareRequirementsId");
        }
    }
}
