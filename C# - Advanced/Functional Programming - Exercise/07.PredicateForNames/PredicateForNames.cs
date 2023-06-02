
//First solution
//Func<List<string>, Predicate<string>, List<string>> validNames = (names, isValid) =>
//{
//    List<string> validNames = new List<string>();

//    foreach(var name in names)
//    {
//        if (isValid(name))
//        {
//            validNames.Add(name);
//        }
//    }

//    return validNames;
//};

//Second solution
Action<List<string>, Predicate<string>> print = (names, isValid) =>
{
    foreach(var name in names)
    {
        if (isValid(name))
        {
            Console.WriteLine(name);
        }
    }
};

int length = int.Parse(Console.ReadLine());

List<string> names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();


Predicate<string> isValid = name =>
{
    return name.Length <= length;
};

//names = validNames(names, isValid);

print(names, isValid);

//foreach(var name in names)
//{
//    Console.WriteLine(name);
//}