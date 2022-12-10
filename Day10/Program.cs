using Day10;

var sampleProgramFile = "program-sample.txt";
var programFile = "program.txt";

var part1SampleAnalyzer = new Analyzer();
var part1SampleSignalStrength = await part1SampleAnalyzer.GetSignalStrenghtSum(sampleProgramFile);
Console.WriteLine();
Console.WriteLine($"Day 10 Part 1 (Sample): Expected Signal Strength is 13140 got {part1SampleSignalStrength}");

var part1Analyzer = new Analyzer();
var part1SignalStrength = await part1Analyzer.GetSignalStrenghtSum(programFile);
Console.WriteLine();
Console.WriteLine($"Day 10 Part 1: Signal Strength is {part1SignalStrength}");
