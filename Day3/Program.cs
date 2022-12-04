using Day3;

var backpacksFilePath = "backpacks.txt";

var backpacks = await BackpackLoader.LoadAsync(backpacksFilePath);

var overlapScore = 0;

foreach(var backpack in backpacks)
{
    var commonChars = backpack.FindOverlappingItemsInCompartments();
    overlapScore += commonChars.ConvertToScore();
}

Console.WriteLine($"Part 1 - Overlap Score: {overlapScore}");


var badgeScore = 0;

for (int i = 0; i < backpacks.Count; i += 3)
{
    var commonChars = backpacks[i].FindOverlappingItems(backpacks[i + 1]);
    commonChars = commonChars.FindOverlappingItems(backpacks[i + 2]);
    badgeScore += commonChars.ConvertToScore();
}

Console.WriteLine($"Part 2 - Badge Score: {badgeScore}");
