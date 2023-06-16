

using _04.Froggy;

List<int> tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();    
Lake lake = new Lake(tokens);

Console.WriteLine(string.Join(", ", lake));