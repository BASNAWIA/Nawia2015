namespace BAS.Nawia.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stage",
                c => new
                    {
                        StageID = c.Int(nullable: false, identity: true),
                        DateStart = c.DateTime(nullable: false),
                        DateEnd = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StageID);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        OwnerId = c.String(),
                        isVisible = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Title = c.String(),
                        TitlePL = c.String(),
                        Description = c.String(),
                        DescriptionPL = c.String(),
                        Tags = c.String(),
                        TagsPL = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.SubjectScope",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        Scope = c.String(),
                        ScopePL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Thesis",
                c => new
                    {
                        ThesisId = c.Int(nullable: false, identity: true),
                        Studentid = c.String(),
                        SupervisorId = c.String(),
                        SubjectId = c.Int(nullable: false),
                        StageId = c.Int(nullable: false),
                        isVisible = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ThesisId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        ConfirmationToken = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        Email = c.String(),
                        IsConfirmed = c.Boolean(nullable: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        Name = c.String(),
                        LastName = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserRoles");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityLogin");
            DropTable("dbo.IdentityClaim");
            DropTable("dbo.User");
            DropTable("dbo.Thesis");
            DropTable("dbo.SubjectScope");
            DropTable("dbo.Subject");
            DropTable("dbo.Stage");
        }
    }
}
