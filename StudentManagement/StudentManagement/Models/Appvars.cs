using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class Appvars
    {

        public static int UserCount
        {
            get
            {
                return (int)HttpContext.Current.Application["UserCount"];
            }
            set
            {
                HttpContext.Current.Application["UserCount"] = value;
            }
        }

        public static int UserNumber
        {
            get
            {
                return (int)HttpContext.Current.Session["UserNumber"];
            }
            set
            {
                HttpContext.Current.Session["UserNumber"] = value;
            }
        }
    }
}