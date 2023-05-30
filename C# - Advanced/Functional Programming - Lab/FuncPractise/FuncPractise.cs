double numberOne = int.Parse(Console.ReadLine());
double numberTwo = int.Parse(Console.ReadLine());
string operation = Console.ReadLine();

Func<double, double, string> mathOperation = null;


switch (operation)
{
    case "+":
        mathOperation = Sum;
        break;
    case "-":
        mathOperation = Minus;
        break;
    case "*":
        mathOperation = Multiply;
        break;
        case "/":
        mathOperation = Dividing;
        break;
}

Console.WriteLine(mathOperation(numberOne, numberTwo));

string Sum (double a, double b)
{
    return $"{a} + {b} = {a+b}";
}

string Minus (double a, double b)
{
    return $"{a} - {b} = {a - b}";
}

string Multiply (double a, double b)
{
    return $"{a} x {b} = {a * b}";
}

string Dividing(double a, double b)
{
    return $"{a} / {b} = {a / b}";
}