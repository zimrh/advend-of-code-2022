using Day8;

var treesSampleFile = "trees-sample.txt";
var sampleForest = await TreesLoader.LoadAsync(treesSampleFile);
Console.WriteLine($"Day 8 Part 1 (Sample): {sampleForest.FindVisibleTreesCount()}");
Console.WriteLine($"Day 8 Part 2 (Sample): {sampleForest.GetHighestViewingScore()}");

var treesFile = "trees.txt";
var forest = await TreesLoader.LoadAsync(treesFile);
Console.WriteLine($"Day 8 Part 1: {forest.FindVisibleTreesCount()}");
Console.WriteLine($"Day 8 Part 2: {forest.GetHighestViewingScore()}");
