namespace club.soundyard.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAgreementColumnToRoles : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetRoles", "Agreement", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetRoles", "Agreement");
        }
    }
}
