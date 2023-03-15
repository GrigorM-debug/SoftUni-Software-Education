using System.Text;

string input = Console.ReadLine();

var outputText = new StringBuilder();

int bompPower = 0;

for (int i = 0; i < input.Length; i++)
{
    char currentCharacter = input[i];   

    if (currentCharacter == '>')
    {
        int currentBompPower = int.Parse(input[i+1].ToString());

        outputText.Append(currentCharacter);

        bompPower += currentBompPower;
    }
    else
    {
        if (bompPower > 0)
        {
            bompPower--;
        }
        else
        {
            outputText.Append(currentCharacter);
        }
    }
}
Console.WriteLine(outputText.ToString());