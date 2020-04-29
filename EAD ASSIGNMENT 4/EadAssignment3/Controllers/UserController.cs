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
        public ActionResult ValidateUser(String token,int id,String name,String login,String password)
        {
            bool flag = false;
            if(token!=null)
            {
                UserDTO user = new UserDTO();
                user.id = id;
                user.name = name;
                user.login = login;
                user.password = password;
                SessionManager.User = user;
                SessionManager.Token = token;
                flag = true;
            }
            var data = new
            {
                success = flag
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
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