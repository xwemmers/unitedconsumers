using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() //: base("TestDB")
        {

        }


        // Dit is een opsomming van tabellen in de DB
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }

    }
}