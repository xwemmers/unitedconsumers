using StudentManagement.Filters;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

namespace StudentManagement.Controllers
{
    //[Authorize(Roles = "Admin")]
    [MyLog]
    [Authorize]
    [HandleError(View ="Error")]
    public class HomeController : Controller
    {
        public ActionResult Error()
        {
            return View();
        }



        // GET: Home

        public ActionResult Index()
        {
            Session["username"] = new Student();
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(User u, bool persistent, string returnUrl)
        {
            var db = new MyDbContext();

            var query = from user in db.Users
                        where user.Name == u.Name && user.Password == u.Password
                        select user;

            var userfound = query.FirstOrDefault();

            if (userfound != null)
            {
                //FormsAuthentication.SetAuthCookie(u.Name, persistent);
                FormsAuthentication.RedirectFromLoginPage(userfound.Name, persistent);
            }

            ViewBag.loginmessage = "Username of password is niet correct!";

            return View(u);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult Contact()
        {
            return View();
        }

        [Authorize(Users = "Xander")]
        public ActionResult CreateStudent()
        {
            return View();
        }

        // Model binding: de gegevens in het formulier worden gematched
        // met de properties van Student s
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users ="Xander")]
        public ActionResult CreateStudent(Student s)
        {
            // Check of het model valid is
            // Zie ook de DataAnnotations op de Student class
            if (ModelState.IsValid)
            {
                var db = new MyDbContext();
                db.Students.Add(s);

                // Als de DB nog niet bestaat wordt hij hier gegenereerd:
                db.SaveChanges();

                // Alles goed gegaan en spring door naar de AllStudents view
                return RedirectToAction("AllStudents");
            }
            else
                return View(s);
        }

        [OutputCache(Duration = 30)] //, Location = OutputCacheLocation.Client)]
        public ActionResult AllStudents()
        {
            // Laat alle studenten zien:
            return View(db.Students.ToList());
        }

        MyDbContext db = new MyDbContext();

        [OutputCache(Duration = 30, VaryByParam ="id")]
        public ActionResult _StudentForm(int id)
        {
            var st = db.Students.Find(id);
            return PartialView(st);
        }

        public ActionResult StudentJson(int id)
        {
            var st = db.Students.Find(id);

            // Deze action geeft geen HTML (View) terug maar JSON data
            return Json(st, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ServerTime()
        {
            return Content(DateTime.Now.ToLongTimeString());
        }

        public ActionResult EenFile()
        {
            return File("bestand.pdf", "text/pdf");
        }

        public ActionResult SearchStudent(string search)
        {
            var q = from s in db.Students
                    where s.Firstname.Contains(search)
                    select s;

            return View("AllStudents", q.ToList());

        }

        public ActionResult Station(int id)
        {
            ViewBag.ID = id;
            return View();
        }

        // http://....Home/EditStudent/2
        public ActionResult EditStudent(int? id)
        {
            //if (id == null)
            //    return RedirectToAction("AllStudents");

            Student s = db.Students.Find(id);

            if (s == null)
                throw new Exception("Niet gevonden!");

            //if (s == null)
            //    return RedirectToAction("AllStudents");

            return View(s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStudent(Student s)
        {
            if (ModelState.IsValid)
            {
                //db.Students.Add(s);
                db.Entry(s).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("AllStudents");
            }
            else
                return View(s);
        }

        public ActionResult ViewStudent(int id)
        {
            Student s = db.Students.Find(id);
            return View(s);
        }

        public ActionResult LijstStudenten()
        {
            return View(db.Students.ToList());
        }

        public ActionResult PartialExamples()
        {
            var s = db.Students.First();
            return View(s);
        }

        [ChildActionOnly]
        public ActionResult _Student(int id)
        {
            var s = db.Students.Find(id);
            return PartialView(s);
        }

        public ActionResult _ExamResult(int id)
        {
            var query = from er in db.ExamResults.Include(x => x.Student)
                        where er.ExamResultID == id
                        select er;

            return PartialView(query.First());
        }

        public ActionResult AllStudentsAjax()
        {

            return View(db.Students.ToList());
        }

        public ActionResult _StudentDetails(int id)
        {
            return PartialView(db.Students.Find(id));
        }

        public ActionResult StudentsByApi()
        {
            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            TempData["foutmelding"] = filterContext.Exception.Message;
        }

    }
}