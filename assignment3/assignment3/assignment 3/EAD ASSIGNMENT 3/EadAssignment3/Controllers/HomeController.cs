using Assignment.BAL;
using Assignment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EadAssignment3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult GetFolders(int uid,int parentFolderId)
        {
            List<FolderDTO> foldersList = FolderBO.getFolders(uid, parentFolderId);
            var data = new
            {
                folders=foldersList,
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreateFolders(String child,int uid,int parentFolder)
        {
            int id = 0;
            bool flag = false; 
            FolderDTO folder = FolderBO.createFolder(child, uid, parentFolder);
            if(folder!=null)
            {
                id = folder.folderId;
                flag = true;
            }
            var data = new
            {
                success = flag,
                folderId = id
            };
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}