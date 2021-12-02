namespace JBUniversity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addbadgescompletedproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "BadgesCompleted", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "BadgesCompleted");
        }
    }
}
