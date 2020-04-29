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

        public static String Token
        {
            get
            {
                String token = null;
                if (HttpContext.Current.Session["token"] != null)
                {
                    token = HttpContext.Current.Session["token"] as String;
                }
                return token;
            }
            set
            {
                HttpContext.Current.Session["token"] = value;
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