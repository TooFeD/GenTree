namespace GenTree.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Childs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        ChildId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Members", t => t.ChildId, cascadeDelete: true)
                .ForeignKey("Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.ChildId);
            
            CreateTable(
                "Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TreeId = c.Int(nullable: false),
                        FirstName = c.String(unicode: false),
                        SecondName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        Sex = c.String(unicode: false),
                        DateOfBirth = c.DateTime(nullable: false, precision: 0),
                        DateOfDeth = c.DateTime(nullable: false, precision: 0),
                        Address = c.String(unicode: false),
                        Photo = c.Binary(),
                        OtherInfo = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Trees", t => t.TreeId, cascadeDelete: true)
                .Index(t => t.TreeId);
            
            CreateTable(
                "HaveDiseases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        GenDiseasesId = c.Int(nullable: false),
                        Dominant = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("GenDiseases", t => t.GenDiseasesId, cascadeDelete: true)
                .ForeignKey("Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.GenDiseasesId);
            
            CreateTable(
                "GenDiseases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        WomenInherited = c.Boolean(nullable: false),
                        MenInherited = c.Boolean(nullable: false),
                        About = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                ;
            
            CreateTable(
                "Parents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("Members", t => t.ParentId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "Trees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        FirstName = c.String(unicode: false),
                        SecondName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        DateOfBith = c.DateTime(nullable: false, precision: 0),
                        Photo = c.Binary(),
                        Email = c.String(maxLength: 256, storeType: "nvarchar"),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(unicode: false),
                        SecurityStamp = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)                
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "Friendships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128, storeType: "nvarchar"),
                        FriendId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        CanSeeTree = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("AspNetUsers", t => t.UserId)
                .ForeignKey("AspNetUsers", t => t.FriendId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.FriendId);
            
            CreateTable(
                "AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        ProviderKey = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })                
                .ForeignKey("AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        RoleId = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })                
                .ForeignKey("AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 256, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)                
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("AspNetUserRoles", "RoleId", "AspNetRoles");
            DropForeignKey("Childs", "MemberId", "Members");
            DropForeignKey("Members", "TreeId", "Trees");
            DropForeignKey("Trees", "ApplicationUserId", "AspNetUsers");
            DropForeignKey("AspNetUserRoles", "UserId", "AspNetUsers");
            DropForeignKey("AspNetUserLogins", "UserId", "AspNetUsers");
            DropForeignKey("Friendships", "FriendId", "AspNetUsers");
            DropForeignKey("Friendships", "UserId", "AspNetUsers");
            DropForeignKey("AspNetUserClaims", "UserId", "AspNetUsers");
            DropForeignKey("Parents", "ParentId", "Members");
            DropForeignKey("Parents", "MemberId", "Members");
            DropForeignKey("HaveDiseases", "MemberId", "Members");
            DropForeignKey("HaveDiseases", "GenDiseasesId", "GenDiseases");
            DropForeignKey("Childs", "ChildId", "Members");
            DropIndex("AspNetRoles", "RoleNameIndex");
            DropIndex("AspNetUserRoles", new[] { "RoleId" });
            DropIndex("AspNetUserRoles", new[] { "UserId" });
            DropIndex("AspNetUserLogins", new[] { "UserId" });
            DropIndex("Friendships", new[] { "FriendId" });
            DropIndex("Friendships", new[] { "UserId" });
            DropIndex("AspNetUserClaims", new[] { "UserId" });
            DropIndex("AspNetUsers", "UserNameIndex");
            DropIndex("Trees", new[] { "ApplicationUserId" });
            DropIndex("Parents", new[] { "ParentId" });
            DropIndex("Parents", new[] { "MemberId" });
            DropIndex("HaveDiseases", new[] { "GenDiseasesId" });
            DropIndex("HaveDiseases", new[] { "MemberId" });
            DropIndex("Members", new[] { "TreeId" });
            DropIndex("Childs", new[] { "ChildId" });
            DropIndex("Childs", new[] { "MemberId" });
            DropTable("AspNetRoles");
            DropTable("AspNetUserRoles");
            DropTable("AspNetUserLogins");
            DropTable("Friendships");
            DropTable("AspNetUserClaims");
            DropTable("AspNetUsers");
            DropTable("Trees");
            DropTable("Parents");
            DropTable("GenDiseases");
            DropTable("HaveDiseases");
            DropTable("Members");
            DropTable("Childs");
        }
    }
}
