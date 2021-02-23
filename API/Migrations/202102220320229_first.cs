namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_M_Account",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tb_M_Employee", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Tb_M_Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BirthDate = c.DateTime(precision: 7, storeType: "datetime2"),
                        Address = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tb_M_Account", "Id", "dbo.Tb_M_Employee");
            DropIndex("dbo.Tb_M_Account", new[] { "Id" });
            DropTable("dbo.Tb_M_Employee");
            DropTable("dbo.Tb_M_Account");
        }
    }
}
