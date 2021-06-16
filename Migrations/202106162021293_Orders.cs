namespace GameShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orders : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Order", "Address", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Order", "PostalCode", c => c.String(nullable: false, maxLength: 6));
            AddColumn("dbo.AspNetUsers", "UserData_Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_Surname", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_City", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_PostalCode", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_Phone", c => c.String());
            AddColumn("dbo.AspNetUsers", "UserData_Email", c => c.String());
            AlterColumn("dbo.Order", "PhoneNumber", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Order", "UserId");
            AddForeignKey("dbo.Order", "UserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Order", "Street");
            DropColumn("dbo.Order", "PostCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "PostCode", c => c.String(nullable: false, maxLength: 6));
            AddColumn("dbo.Order", "Street", c => c.String(nullable: false, maxLength: 100));
            DropForeignKey("dbo.Order", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Order", new[] { "UserId" });
            AlterColumn("dbo.Order", "PhoneNumber", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserData_Email");
            DropColumn("dbo.AspNetUsers", "UserData_Phone");
            DropColumn("dbo.AspNetUsers", "UserData_PostalCode");
            DropColumn("dbo.AspNetUsers", "UserData_City");
            DropColumn("dbo.AspNetUsers", "UserData_Address");
            DropColumn("dbo.AspNetUsers", "UserData_Surname");
            DropColumn("dbo.AspNetUsers", "UserData_Name");
            DropColumn("dbo.Order", "PostalCode");
            DropColumn("dbo.Order", "Address");
            DropColumn("dbo.Order", "UserId");
        }
    }
}
