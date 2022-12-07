using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal static class FolderExtensions
    {
        public static double GetFolderSize(this Dictionary<string, Folder> folders, string path)
        {
            double size = 0;

            foreach(var folder in folders)
            {
                if (!folder.Key.StartsWith(path))
                {
                    continue;
                }

                size += folder.Value.Files.Sum(f => f.Size);
            }

            return size;
        }
    }
}
