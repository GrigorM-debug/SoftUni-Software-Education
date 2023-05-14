using System.Globalization;

string[] input = Console.ReadLine().Split();

Stack<string> expressions = new Stack<string>(input.Reverse());  

int result = int.Parse(expressions.Pop());

while(expressions.Count > 0)
{
    string mathOperation = expressions.Pop();
    int number = int.Parse(expressions.Pop());
    if (mathOperation == "+")
    {
        result += number;
    }
    else if (mathOperation == "-")
    {
        result -= number;
    }
}
Console.WriteLine(result);