namespace Single_Page_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MeetingMinutesDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeetingMinutesMasterId = c.Int(nullable: false),
                        ProductServiceId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MeetingMinutesMasters", t => t.MeetingMinutesMasterId, cascadeDelete: true)
                .Index(t => t.MeetingMinutesMasterId);
            
            CreateTable(
                "dbo.MeetingMinutesMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Time = c.String(),
                        MeetingPlace = c.String(),
                        AttendsFromClientSide = c.String(),
                        AttendsFromHostSide = c.String(),
                        MeetingAgenda = c.String(),
                        MeetingDiscussion = c.String(),
                        MeetingDecision = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MeetingMinutesDetails", "MeetingMinutesMasterId", "dbo.MeetingMinutesMasters");
            DropIndex("dbo.MeetingMinutesDetails", new[] { "MeetingMinutesMasterId" });
            DropTable("dbo.ProductServices");
            DropTable("dbo.MeetingMinutesMasters");
            DropTable("dbo.MeetingMinutesDetails");
            DropTable("dbo.Customers");
        }
    }
}
