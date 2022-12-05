using Day5;

var stackfilePath = "ship.txt";
var shipPart1 = await ShipLoader.LoadAsync(stackfilePath);
var topCratesPart1 = shipPart1.ExecuteInstructions(Crane.BasicCrane);
Console.WriteLine($"Top Crates Using a Basic Crane Are: {topCratesPart1}");

var shipPart2 = await ShipLoader.LoadAsync(stackfilePath);
var topCratesPart2 = shipPart2.ExecuteInstructions(Crane.CrateMover9001);
Console.WriteLine($"Top Crates Using the CrateMover 9001 Are: {topCratesPart2}");