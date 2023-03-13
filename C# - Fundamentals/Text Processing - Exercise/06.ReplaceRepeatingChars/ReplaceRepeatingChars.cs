using System.Text;

string input  = Console.ReadLine();

StringBuilder newstring = new StringBuilder();      
for (int i = 0; i < input.Length; i++)
{
    while (i < input.Length-1 && input[i] == input[i + 1])
    {
        i++;
    }

    newstring.Append(input[i]);
}
Console.WriteLine(newstring.ToString());