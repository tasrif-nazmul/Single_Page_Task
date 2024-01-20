namespace Single_Page_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeAtable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MeetingMinutesDetails", "MeetingMinutesMasterId", "dbo.MeetingMinutesMasters");
            DropIndex("dbo.MeetingMinutesDetails", new[] { "MeetingMinutesMasterId" });
            RenameColumn(table: "dbo.MeetingMinutesDetails", name: "MeetingMinutesMasterId", newName: "MeetingMinutesMaster_Id");
            AddColumn("dbo.MeetingMinutesDetails", "InterestProduct", c => c.String());
            AddColumn("dbo.MeetingMinutesDetails", "Unit", c => c.String());
            AlterColumn("dbo.MeetingMinutesDetails", "MeetingMinutesMaster_Id", c => c.Int());
            CreateIndex("dbo.MeetingMinutesDetails", "MeetingMinutesMaster_Id");
            AddForeignKey("dbo.MeetingMinutesDetails", "MeetingMinutesMaster_Id", "dbo.MeetingMinutesMasters", "Id");
            DropColumn("dbo.MeetingMinutesDetails", "ProductServiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MeetingMinutesDetails", "ProductServiceId", c => c.Int(nullable: false));
            DropForeignKey("dbo.MeetingMinutesDetails", "MeetingMinutesMaster_Id", "dbo.MeetingMinutesMasters");
            DropIndex("dbo.MeetingMinutesDetails", new[] { "MeetingMinutesMaster_Id" });
            AlterColumn("dbo.MeetingMinutesDetails", "MeetingMinutesMaster_Id", c => c.Int(nullable: false));
            DropColumn("dbo.MeetingMinutesDetails", "Unit");
            DropColumn("dbo.MeetingMinutesDetails", "InterestProduct");
            RenameColumn(table: "dbo.MeetingMinutesDetails", name: "MeetingMinutesMaster_Id", newName: "MeetingMinutesMasterId");
            CreateIndex("dbo.MeetingMinutesDetails", "MeetingMinutesMasterId");
            AddForeignKey("dbo.MeetingMinutesDetails", "MeetingMinutesMasterId", "dbo.MeetingMinutesMasters", "Id", cascadeDelete: true);
        }
    }
}
