using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class Folder
    {
        public Folder(string basePath)
        {
            ParentFolder = basePath;
        }

        public Guid Id { get; set;}
        public string ParentFolder { get; set; }
        public List<string> ChildFolders { get; set; } = new();
        public List<File> Files = new();
    }
}
