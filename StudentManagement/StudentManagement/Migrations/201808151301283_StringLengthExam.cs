namespace StudentManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringLengthExam : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exams", "Code", c => c.String(maxLength: 10));
            AlterColumn("dbo.Exams", "Description", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exams", "Description", c => c.String());
            AlterColumn("dbo.Exams", "Code", c => c.String());
        }
    }
}
