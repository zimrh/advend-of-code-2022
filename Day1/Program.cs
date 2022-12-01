using Day1;

var caloriesPath = "calories.txt";

var elves = ElfLoader.Load(caloriesPath);
Console.WriteLine($"Elves loaded: {elves.Count}");

// Could use foreach and store values etc but going with a LINQ expression for now

var topThreeElves = elves.OrderByDescending(e => e.FoodItemsTotalCalories).Take(3).ToList();

Console.WriteLine($"Top Elfs Calorie Count: {topThreeElves.First().FoodItemsTotalCalories}");

var topThreeElvesCalorieCount = topThreeElves.Sum(e => e.FoodItemsTotalCalories);
Console.WriteLine($"Top 3 Elves Calorie Count: {topThreeElvesCalorieCount}");