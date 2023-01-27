string[] daysOfWeek = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday",
"Saturday", "Sunday"};

int input = int.Parse(Console.ReadLine());
if (input >= 1 && input <= 7)
{
    Console.WriteLine(daysOfWeek[input-1]);
}
else
{
    Console.WriteLine("Invalid day!");
}
