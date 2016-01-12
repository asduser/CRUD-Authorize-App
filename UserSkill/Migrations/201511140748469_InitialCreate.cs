namespace UserSkill.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.SkillUser",
                c => new
                    {
                        SkillId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SkillId, t.UserId })
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.SkillId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SkillUser", "UserId", "dbo.Users");
            DropForeignKey("dbo.SkillUser", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.Users", "CityId", "dbo.Cities");
            DropIndex("dbo.SkillUser", new[] { "UserId" });
            DropIndex("dbo.SkillUser", new[] { "SkillId" });
            DropIndex("dbo.Users", new[] { "CityId" });
            DropTable("dbo.SkillUser");
            DropTable("dbo.Users");
            DropTable("dbo.Skills");
            DropTable("dbo.Cities");
        }
    }
}
