using System.Reflection.Metadata.Ecma335;

//First Solution
//Func<List<int>, Predicate<int>, List<int>> validNumbers = (numbers, isDivisible) =>
//{
//    List<int> result = new List<int>();

//    foreach(var number in numbers)
//    {
//        if (!isDivisible(number))
//        {
//            result.Add(number);
//        }
//    }

//    return result;
//};

//Func<List<int>, List<int>> reverseNumbers = numbers =>
//{
//    List<int> result = new List<int>();

//    for (int i = numbers.Count - 1; i >= 0; i--)
//    {
//        result.Add(numbers[i]);
//    }

//    return result;
//};

//Second solution
Func<List<int>, Predicate<int>, List<int>> reverseNumbers = (numbers, isDivisible) =>
{
    List<int> result = new List<int>();

    for (int i = numbers.Count - 1; i >= 0; i--)
    {
        if (!isDivisible(numbers[i]))
        {
            result.Add(numbers[i]);
        }
    }

    return result;
};

List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

int divider = int.Parse(Console.ReadLine());

Predicate<int> isDivisible = number =>
{
    return number % divider == 0;
};

//numbers = validNumbers(numbers, isDivisible);
numbers = reverseNumbers(numbers, isDivisible);

Console.WriteLine($"{string.Join(" ", numbers)}");