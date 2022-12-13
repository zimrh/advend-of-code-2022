using Day13;

var sampleFile = "sample.txt";
var inputFile = "input.txt";

var part1SamplePacketAnalysis = await PacketAnalyzer.AnalyzePacketsAsync(sampleFile);
Console.WriteLine($"Day 13 Part 1 (Sample): Valid Packet Score {part1SamplePacketAnalysis}");

var part1PacketAnalysis = await PacketAnalyzer.AnalyzePacketsAsync(inputFile);
Console.WriteLine($"Day 13 Part 1: Valid Packet Score {part1PacketAnalysis}");

var part2SamplePacketSort = await PacketAnalyzer.BubbleSortPacketsAsync(sampleFile);
Console.WriteLine($"Day 13 Part 2 (Sample): Sorted Divider Score {part2SamplePacketSort}");

var part2PacketSort = await PacketAnalyzer.BubbleSortPacketsAsync(inputFile);
Console.WriteLine($"Day 13 Part 2: Sorted Divider Score {part2PacketSort}");