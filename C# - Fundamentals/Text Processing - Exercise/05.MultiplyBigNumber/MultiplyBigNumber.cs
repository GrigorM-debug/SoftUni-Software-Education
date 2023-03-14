using System.Text;

string number = Console.ReadLine();
int multiplier = int.Parse(Console.ReadLine());

var finalResult = new StringBuilder();

int remainder = 0;


if (multiplier == 0 || number == "0")
{
    Console.WriteLine(0);
    return;
}

for (int i = number.Length - 1; i >= 0; i--)
{
    int currNum = int.Parse(number[i].ToString());
    int product = currNum * multiplier + remainder;
    int result = product % 10;
    remainder = product / 10;

    finalResult.Insert(0, result);
}
if (remainder > 0)
{
    finalResult.Insert(0, remainder);
}

Console.WriteLine(finalResult.ToString());