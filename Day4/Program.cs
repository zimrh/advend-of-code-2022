// See https://aka.ms/new-console-template for more information
using Day4;

var assignmentsFile = "assignments.txt";

var groups = await AssignmentLoader.LoadAsync(assignmentsFile);

Console.WriteLine($"{groups.Count} groups loaded");

var fullyContainedCount = groups.Count(g => g[0].Contains(g[1]) || g[1].Contains(g[0]));

Console.WriteLine($"Day 4 - Part 1 - Contained Plan Count: {fullyContainedCount}");

var overlapCount = groups.Count(g => g[0].HasAnyOverlap(g[1]));

Console.WriteLine($"Day 4 - Part 2 - Plans with Overlap: {overlapCount}");