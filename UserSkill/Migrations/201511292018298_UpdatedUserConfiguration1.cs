namespace UserSkill.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUserConfiguration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
