using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class ConsoleParser
    {
        public static async Task<Dictionary<string, Folder>> ParseAsync(string consoleOutputFilePath)
        {
            var folders = new Dictionary<string, Folder>();
            folders.Add("/", new Folder("/"));
            
            var currentPath = new Stack<string>();
            currentPath.Push("/");

            

            await foreach (var line in FileLoader.GetLinesAsync(consoleOutputFilePath))
            {
                if (line[0] == '$')
                {
                    var commands = line.ToLowerInvariant().Split(" ");

                    if (string.Equals(commands[1], "cd", StringComparison.OrdinalIgnoreCase))
                    {
                        switch (commands[2])
                        {
                            case "..":
                                currentPath.Pop();
                                break;

                            case "/":
                                currentPath.Clear();
                                continue;

                            default:
                                var basePath = GetCurrentPath(currentPath);
                                currentPath.Push(commands[2]);
                                var newPath = GetCurrentPath(currentPath);
                                if (!folders.ContainsKey(newPath))
                                {
                                    folders.Add(newPath, new Folder(basePath));
                                }
                                folders[basePath].ChildFolders.Add(newPath);
                                break;
                        }
                    }
                }
                else
                {
                    var listing = line.Split(" ");
                    if (listing[0] != "dir")
                    {
                        var folder = folders[GetCurrentPath(currentPath)];
                        folder.Files.Add(new File()
                        {
                            Size = double.Parse(listing[0]),
                            Name = listing[1]
                        });
                    }
                }
            }

            return folders;
        }

        private static string GetCurrentPath(Stack<string> currentPath)
        {
            return "/" + string.Join("/",currentPath.Reverse());
        }
    }
}
