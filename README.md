# Advent of Code 2022

December again, what happened to the year! Setting off on another elf adventure

Join in the fun at [adventofcode.com](https://adventofcode.com/2022)

## Build

Trying out github actions, so far very impressed.  

| Action | Status |
|--------------|---|
| Build Status | [![.NET](https://github.com/zimrh/advent-of-code-2022/actions/workflows/dotnet.yml/badge.svg)](https://github.com/zimrh/advent-of-code-2022/actions/workflows/dotnet.yml) |
| Unit Tests | TBD |

## Thoughts

### General

Testcase instead of console app? 

Oh definitely this now that we have github actions!  I wonder if we can break the build and unit tests into two different actions which hopefully can be linked.  i.e. build > unit tests instead of all in one action

### Day 4

Had a moment where I neededed to work out the logic for if items are contained within other items
so sketched the following very roughly on a piece of paper I had handy:

![Lines](./Day4/LinesToHelpMePutTheLogicTogether.png)

Helped with the logic for `Contains` and `HasAnyOverlap`

### Day 6

I have written two different signal analyzers for this solution, the first implementation assumes 
that you will be able to read and store the entire signal before analyzing it. I have put the code
for that in the `StaticSignalAnalyzer.cs`

HOWEVER!

Based on previous work I have done with DMX signals you will very rarely be able to or even want
to read the entire signal into memory and then analyze it.

I have therefore written additional code to accept one character at a time (as if it was coming off
a stream) and to set a flag and record a position once the specified marker is reached.

Ideally I would create an event that the consumer could subscribe to and which would fire when the 
marker is reached but this will do for now.  If I get enough free time I will come back around to
this question and rework it.
