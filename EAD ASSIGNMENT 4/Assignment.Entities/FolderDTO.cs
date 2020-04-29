using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Entities
{
    public class FolderDTO
    {
        public int folderId { get; set; }

        public String folderName { get; set; }

        public int parentFolderId { get; set; }

        public int id { get; set; }
    }
}
