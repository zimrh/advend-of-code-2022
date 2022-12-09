using Day9;

var ropesSampleFile = "rope-sample.txt";
var ropesLongerSampleFile = "rope-longer-sample.txt";
var ropesFile = "rope.txt";

var sampleRopeTailMovementCount = await RopeSimulator.GetTailMovementCount(ropesSampleFile, 2);
Console.WriteLine($"Day 9 Part 1 (Sample): Tail Movement: {sampleRopeTailMovementCount}");

var ropeTailMovementCount = await RopeSimulator.GetTailMovementCount(ropesFile, 2);
Console.WriteLine($"Day 9 Part 1: Tail Movement: {ropeTailMovementCount}");

var sampleLongRopeTailMovementCount = await RopeSimulator.GetTailMovementCount(ropesLongerSampleFile, 10);
Console.WriteLine($"Day 9 Part 2 (Larger Sample): Tail Movement: {sampleLongRopeTailMovementCount}");

var longRopeTailMovementCount2 = await RopeSimulator.GetTailMovementCount(ropesFile, 10);
Console.WriteLine($"Day 9 Part 2: Tail Movement: {longRopeTailMovementCount2}");
