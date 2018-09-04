using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Data.Entity;
using StudentManagement.Models;
using StudentManagement.Filters;
using System.Diagnostics;

namespace StudentManagement
{
    public class Global : HttpApplication
    {

        void Session_Start(object sender, EventArgs e)
        {
            //Application["UserCount"] = (int)Application["UserCount"] + 1;
            Appvars.UserCount++;
            Appvars.UserNumber = Appvars.UserCount;
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database.SetInitializer(new MyInitializer());

            Appvars.UserCount = 0;

            GlobalFilters.Filters.Add(new MyLogAttribute());
        }

        void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();

            Debug.WriteLine(ex.Message);
        }
    }
}