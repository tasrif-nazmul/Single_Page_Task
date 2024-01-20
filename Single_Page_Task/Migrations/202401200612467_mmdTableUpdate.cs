namespace Single_Page_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mmdTableUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MeetingMinutesDetails", "MeetingMinutesMaster_Id", "dbo.MeetingMinutesMasters");
            DropIndex("dbo.MeetingMinutesDetails", new[] { "MeetingMinutesMaster_Id" });
            AlterColumn("dbo.MeetingMinutesDetails", "MeetingMinutesMaster_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.MeetingMinutesDetails", "MeetingMinutesMaster_Id");
            AddForeignKey("dbo.MeetingMinutesDetails", "MeetingMinutesMaster_Id", "dbo.MeetingMinutesMasters", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MeetingMinutesDetails", "MeetingMinutesMaster_Id", "dbo.MeetingMinutesMasters");
            DropIndex("dbo.MeetingMinutesDetails", new[] { "MeetingMinutesMaster_Id" });
            AlterColumn("dbo.MeetingMinutesDetails", "MeetingMinutesMaster_Id", c => c.Int());
            CreateIndex("dbo.MeetingMinutesDetails", "MeetingMinutesMaster_Id");
            AddForeignKey("dbo.MeetingMinutesDetails", "MeetingMinutesMaster_Id", "dbo.MeetingMinutesMasters", "Id");
        }
    }
}
