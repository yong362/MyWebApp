namespace TestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.unitTypes",
                c => new
                    {
                        unitTypeID = c.Int(nullable: false, identity: true),
                        typeName = c.String(),
                    })
                .PrimaryKey(t => t.unitTypeID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.unitTypes");
        }
    }
}
