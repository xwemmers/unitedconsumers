namespace StudentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExamResultNewTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExamResults",
                c => new
                    {
                        ExamResultID = c.Int(nullable: false, identity: true),
                        ExamDate = c.DateTime(nullable: false),
                        Score = c.Int(nullable: false),
                        Exam_ExamID = c.Int(),
                        Student_StudentID = c.Int(),
                    })
                .PrimaryKey(t => t.ExamResultID)
                .ForeignKey("dbo.Exams", t => t.Exam_ExamID)
                .ForeignKey("dbo.Students", t => t.Student_StudentID)
                .Index(t => t.Exam_ExamID)
                .Index(t => t.Student_StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamResults", "Student_StudentID", "dbo.Students");
            DropForeignKey("dbo.ExamResults", "Exam_ExamID", "dbo.Exams");
            DropIndex("dbo.ExamResults", new[] { "Student_StudentID" });
            DropIndex("dbo.ExamResults", new[] { "Exam_ExamID" });
            DropTable("dbo.ExamResults");
        }
    }
}
