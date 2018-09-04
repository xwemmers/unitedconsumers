namespace StudentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fkeyveld : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExamResults", "Exam_ExamID", "dbo.Exams");
            DropIndex("dbo.ExamResults", new[] { "Exam_ExamID" });
            RenameColumn(table: "dbo.ExamResults", name: "Exam_ExamID", newName: "ExamID");
            AlterColumn("dbo.ExamResults", "ExamID", c => c.Int(nullable: false));
            CreateIndex("dbo.ExamResults", "ExamID");
            AddForeignKey("dbo.ExamResults", "ExamID", "dbo.Exams", "ExamID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamResults", "ExamID", "dbo.Exams");
            DropIndex("dbo.ExamResults", new[] { "ExamID" });
            AlterColumn("dbo.ExamResults", "ExamID", c => c.Int());
            RenameColumn(table: "dbo.ExamResults", name: "ExamID", newName: "Exam_ExamID");
            CreateIndex("dbo.ExamResults", "Exam_ExamID");
            AddForeignKey("dbo.ExamResults", "Exam_ExamID", "dbo.Exams", "ExamID");
        }
    }
}
