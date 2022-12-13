
using Day12;

var sampleElevationFile = "elevations-sample.txt";
var elevationFile = "elevations.txt";

var part1SampleMap = await ElevationLoader.LoadAsync(sampleElevationFile);
var part1SampleMinimumSteps = part1SampleMap.GetShortestClimb();
Console.WriteLine($"Day 12 Part 1 (Sample): Expected 31 steps, Got {part1SampleMinimumSteps} steps");

var part1Map = await ElevationLoader.LoadAsync(elevationFile);
var part1MinimumSteps = part1Map.GetShortestClimb();
Console.WriteLine($"Day 12 Part 1: Shortest Path: {part1MinimumSteps} steps");

var part2SampleMap = await ElevationLoader.LoadAsync(sampleElevationFile);
var part2SampleMinimumSteps = part2SampleMap.GetShortestDescent();
Console.WriteLine($"Day 12 Part 2 (Sample): Expected 29 steps, Got {part2SampleMinimumSteps} steps");

var part2Map = await ElevationLoader.LoadAsync(elevationFile);
var part2MinimumSteps = part2Map.GetShortestDescent();
Console.WriteLine($"Day 12 Part 2: Shortest Descent: {part2MinimumSteps} steps");