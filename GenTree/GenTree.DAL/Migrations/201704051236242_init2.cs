namespace GenTree.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("Friendships", "Accepted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Friendships", "Accepted");
        }
    }
}
