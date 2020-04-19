using Assignment.BAL;
using Assignment.Entities;
using EadAssignment3.Securtiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EadAssignment3.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ValidateUser(String Login,String Password)
        {
            UserDTO user = UserBO.validateUser(Login, Password);
            bool flag = false;
            if (user!=null)
            {
                SessionManager.User = user;
                flag = true;
            }
            var data = new
            {
               success=flag
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult RegisterUser(UserDTO user)
        {
            int id = UserBO.save(user);
            bool flag = true;
            if(id==0)
            {
                flag = false;
            }
            else
            {
                user.id = id;
                SessionManager.User = user;
            }
            var data = new
            {
                success = flag
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Home()
        {
            if(SessionManager.IsValidUser)
            {
                return View();
            }
            else
            {
                return Redirect("~/User/Login");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            SessionManager.ClearSession();
            return Redirect("~/User/Login");
        }
    }
}