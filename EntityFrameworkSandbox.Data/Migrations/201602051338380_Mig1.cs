namespace garpunkal.EntityFrameworkSandbox.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Developer",
                c => new
                    {
                        DeveloperId = c.Guid(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        UpdatedDateTime = c.DateTime(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.DeveloperId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Developer");
        }
    }
}
