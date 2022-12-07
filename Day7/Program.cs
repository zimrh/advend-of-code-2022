using Day7;

var consoleOutputFile = "console-output.txt";
var folders = await ConsoleParser.ParseAsync(consoleOutputFile);

double totalSize = 0;
var minimumSize = 100000;

Console.WriteLine($"== Part 1 Folders under {minimumSize} ==");
foreach (var folder in folders)
{
    var folderSize = folders.GetFolderSize(folder.Key);
    if (folderSize > minimumSize)
    {
        continue;
    }
    Console.WriteLine($"{folder.Key} - {folderSize}");
    totalSize += folderSize;
}

Console.WriteLine($"Day 7 Part 1: Total Size of small folders: {totalSize}");

double storageSize = 70000000;
double minimumSpaceRequiredForUpdate = 30000000;

var usedSpace = folders.GetFolderSize("/");
var currentFreeSpace = storageSize - usedSpace;
double minimumNeededSpace = minimumSpaceRequiredForUpdate - currentFreeSpace;

var smallestFolderSize = double.MaxValue;
var smallestFolderId = string.Empty;

foreach (var folder in folders)
{
    var folderSize = folders.GetFolderSize(folder.Key);
    if (folderSize < minimumNeededSpace)
    {
        continue;
    }

    if (folderSize < smallestFolderSize)
    {
        smallestFolderSize = folderSize;
        smallestFolderId = folder.Key;
    }
}

Console.WriteLine($"Smallest folder: {smallestFolderId} is size {smallestFolderSize}");