string input = Console.ReadLine();

List<string> numbers = new List<string>();
List<string> letters = new List<string>();
List<string> others = new List<string>();   


for(int i = 0; i < input.Length; i++)
{
    if ((input[i] >= 'a' && input[i] <= 'z') || (input[i] >= 'A' && input[i] <= 'Z'))
    {
        letters.Add(input[i].ToString());
    }
    else if ((input[i] >= '0'&& input[i] <='9'))
    {
        numbers.Add(input[i].ToString());
    }
    else
    {
        others.Add(input[i].ToString());
    }
}
Console.WriteLine(string.Join("", numbers));
Console.WriteLine(string.Join("", letters));
Console.WriteLine(string.Join("", others));