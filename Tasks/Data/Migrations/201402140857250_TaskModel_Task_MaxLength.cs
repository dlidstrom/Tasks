using System.Data.Entity.Migrations;

namespace Tasks.Data.Migrations
{
    public partial class TaskModel_Task_MaxLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TaskModels", "Task", c => c.String(nullable: false, maxLength: 1024));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TaskModels", "Task", c => c.String(nullable: false));
        }
    }
}
