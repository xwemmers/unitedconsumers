namespace StudentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkeyStudent : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExamResults", "Student_StudentID", "dbo.Students");
            DropIndex("dbo.ExamResults", new[] { "Student_StudentID" });
            RenameColumn(table: "dbo.ExamResults", name: "Student_StudentID", newName: "StudentID");
            AlterColumn("dbo.ExamResults", "StudentID", c => c.Int(nullable: false));
            CreateIndex("dbo.ExamResults", "StudentID");
            AddForeignKey("dbo.ExamResults", "StudentID", "dbo.Students", "StudentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamResults", "StudentID", "dbo.Students");
            DropIndex("dbo.ExamResults", new[] { "StudentID" });
            AlterColumn("dbo.ExamResults", "StudentID", c => c.Int());
            RenameColumn(table: "dbo.ExamResults", name: "StudentID", newName: "Student_StudentID");
            CreateIndex("dbo.ExamResults", "Student_StudentID");
            AddForeignKey("dbo.ExamResults", "Student_StudentID", "dbo.Students", "StudentID");
        }
    }
}
