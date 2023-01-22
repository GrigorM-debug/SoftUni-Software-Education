int lostGame = int.Parse(Console.ReadLine());
double headsetPrice = double.Parse(Console.ReadLine());
double mousePrice = double.Parse(Console.ReadLine());
double keyboardPrice = double.Parse(Console.ReadLine());
double displayPrice = double.Parse(Console.ReadLine());

double trashedHeadset = 0.0;
double trashedMouse = 0.0;
double trashedKeyboard = 0.0;
double trashedDisplay = 0.0;

for (int i = 1; i <= lostGame; i++)
{
    if (i % 2 == 0)
    {
        trashedHeadset++;
    }
    if (i % 3 == 0)
    {
        trashedMouse++;
    }
    if (i % 2 == 0 && i % 3 == 0)
    {
        trashedKeyboard++;

        if (trashedKeyboard % 2 == 0)
        {
            trashedDisplay++;
        }
    }
}

double expenses = trashedHeadset + trashedMouse + trashedKeyboard + trashedDisplay;
Console.WriteLine($"Rage expenses: {expenses:f2} lv.");