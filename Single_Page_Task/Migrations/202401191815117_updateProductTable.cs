namespace Single_Page_Task.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductServices", "Quantity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductServices", "Quantity");
        }
    }
}
