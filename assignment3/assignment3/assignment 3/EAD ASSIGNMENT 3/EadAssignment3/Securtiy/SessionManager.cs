using Assignment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EadAssignment3.Securtiy
{
    public static class SessionManager
    {
        public static UserDTO User
        {
            get
            {
                UserDTO user = null;
                if (HttpContext.Current.Session["user"] != null)
                {
                    user = HttpContext.Current.Session["user"] as UserDTO;
                }
                return user;
            }
            set
            {
                HttpContext.Current.Session["user"] = value;
            }
        }

        public static bool IsValidUser
        {
            get
            {
                if(User!=null)
                {
                    return true;
                }
                return false;
            }
        }

        public static void ClearSession()
        {
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Abandon();
        }
    }
}