using Assignment.DAL;
using Assignment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.BAL
{
    public static class FolderBO
    {
        public static List<FolderDTO> getFolders(int uid, int pfid)
        {
            return FolderDAO.getFolders(uid, pfid);
        }
        public static FolderDTO createFolder(String child, int uid, int parentFolder)
        {
            return FolderDAO.createFolder(child, uid, parentFolder);
        }
    }
}
