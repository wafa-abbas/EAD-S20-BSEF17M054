using Assignment.BAL;
using Assignment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace Assignment_WebApi.Controllers
{
    public class HomeController : ApiController
    {
        [Authorize]
        [HttpPost]
        public Object GetFolders( )
        {
            var identity = User.Identity as ClaimsIdentity;
            Object data=null;
            if(identity !=null)
            {
                int uid = Int32.Parse(HttpContext.Current.Request["uid"]);
                int parentFolderId = Int32.Parse(HttpContext.Current.Request["parentFolderId"]);
                List<FolderDTO> foldersList = FolderBO.getFolders(uid, parentFolderId);
                data = new
                {
                    folders = foldersList,
                };
            }
            return data;
        }


        [Authorize]
        [HttpPost]
        public Object CreateFolders()
        {
            var identity = User.Identity as ClaimsIdentity;
            Object data = null;
            String child = HttpContext.Current.Request["child"];
            int uid = Int32.Parse(HttpContext.Current.Request["uid"]);
            int parentFolder = Int32.Parse(HttpContext.Current.Request["parentFolder"]);
            if (identity!=null)
            {
                int id = 0;
                bool flag = false;
                FolderDTO folder = FolderBO.createFolder(child, uid, parentFolder);
                if (folder != null)
                {
                    id = folder.folderId;
                    flag = true;
                }
                data = new
                {
                    success = flag,
                    folderId = id
                };
            }
            return data;
        }
    }
}
