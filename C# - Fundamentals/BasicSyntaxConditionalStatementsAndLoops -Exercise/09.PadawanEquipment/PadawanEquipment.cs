using System.IO.Pipes;

double JohnMoney = double.Parse(Console.ReadLine());
int studentsCnt = int.Parse(Console.ReadLine());
double priceForOneLightSaber = double.Parse(Console.ReadLine());  
double priceForOneRobe = double.Parse(Console.ReadLine());  
double priceForOneBelt = double.Parse(Console.ReadLine());

int freeBelts = (studentsCnt / 6);

//Calculating the prices for equipment
double lightSabersPrice = priceForOneLightSaber * (Math.Ceiling(studentsCnt + studentsCnt * 0.10));
double robesPrice = priceForOneRobe * (studentsCnt);
double beltsPrice = priceForOneBelt * (studentsCnt - freeBelts);

//Calculating the total price for all shits
double totalPrice = lightSabersPrice + robesPrice + beltsPrice;

if (totalPrice <= JohnMoney)
{
    Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
}
else
{
    double neededMoney = totalPrice - JohnMoney;
    Console.WriteLine($"John will need {neededMoney:f2}lv more.");
}