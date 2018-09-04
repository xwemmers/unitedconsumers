using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentManagement.Controllers
{
    public class StudentApiController : ApiController
    {
        MyDbContext db = new MyDbContext();

        public List<Student> Get()
        {
            return db.Students.ToList();
        }


        public Student Get(int id)
        {
            return db.Students.Find(id);
        }

        // ....?search=X

        public List<Student> Get(string search)
        {
            var q = from s in db.Students
                    where s.Firstname.Contains(search)
                    select s;

            // Voor Michael:
            //var q2 = db.Students.Where(st => st.Firstname.Contains(search));

            return q.ToList();
        }



        public void Post(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();
        }

        public void Put(int id, Student s)
        {
            // De id komt van de URL en deze zou gelijk moeten zijn aan s.StudentID

            db.Entry(s).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var s = new Student();
            s.StudentID = id;

            db.Entry(s).State = EntityState.Deleted;

            db.SaveChanges();
        }
    }
}
