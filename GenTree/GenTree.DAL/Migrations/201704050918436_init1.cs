namespace GenTree.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Marriages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        MarriagId = c.Int(nullable: false),
                        IsMarriade = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)                
                .ForeignKey("Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("Members", t => t.MarriagId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.MarriagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Marriages", "MarriagId", "Members");
            DropForeignKey("Marriages", "MemberId", "Members");
            DropIndex("Marriages", new[] { "MarriagId" });
            DropIndex("Marriages", new[] { "MemberId" });
            DropTable("Marriages");
        }
    }
}
