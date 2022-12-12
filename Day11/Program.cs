using Day11;

var part1SampleMonkeyFile = "monkeys-sample.txt";
var part1SampleMonkeys = await MonkeyLoader.LoadAsync(part1SampleMonkeyFile);
var part1SampleMonkeyBusinessScore = WorrySimulator.GetMonkeyBusinessScore(part1SampleMonkeys, 20);
Console.WriteLine($"Day11 Part 1 (Sample): Monkey Business Score is meant to be: 10605 we got: {part1SampleMonkeyBusinessScore}");

var part1MonkeyFile = "monkeys.txt";
var part1Monkeys = await MonkeyLoader.LoadAsync(part1MonkeyFile);
var part1MonkeyBusinessScore = WorrySimulator.GetMonkeyBusinessScore(part1Monkeys, 20);
Console.WriteLine($"Day11 Part 1: Monkey Business Score is: {part1MonkeyBusinessScore}");

var part2SampleMonkeyFile = "monkeys-sample.txt";
var part2SampleMonkeys = await MonkeyLoader.LoadAsync(part2SampleMonkeyFile);
var part2SampleMonkeyBusinessScore = WorrySimulator.GetMonkeyBusinessScore(part2SampleMonkeys, 10000, false);
Console.WriteLine($"Day11 Part 2 (Sample): Monkey Business Score is meant to be: 2713310158 we got: {part2SampleMonkeyBusinessScore}");

var part2MonkeyFile = "monkeys.txt";
var part2Monkeys = await MonkeyLoader.LoadAsync(part2MonkeyFile);
var part2MonkeyBusinessScore = WorrySimulator.GetMonkeyBusinessScore(part2Monkeys, 10000, false);
Console.WriteLine($"Day11 Part 2: Monkey Business Score is: {part2MonkeyBusinessScore}");