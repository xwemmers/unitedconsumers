using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace StudentManagement.Models
{
    public class MyInitializer : DropCreateDatabaseIfModelChanges<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            context.Exams.Add(new Exam
            {
                Code = "70-486",
                Description = "ASP.NET MVC"
            });

            context.Exams.Add(new Exam
            {
                Code = "70-483",
                Description = "C#"
            });

            context.Users.Add(new User
            {
                Name = "Xander",
                Password = "secret"
            });

            context.Users.Add(new User
            {
                Name = "Martijn",
                Password = "unknown"
            });

            context.SaveChanges();
        }
    }
}