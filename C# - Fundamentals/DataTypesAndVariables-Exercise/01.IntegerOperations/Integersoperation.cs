int firstNumber = int.Parse(Console.ReadLine());
int secondNumber = int.Parse(Console.ReadLine());
int thirdNumber = int.Parse(Console.ReadLine());   
int fourthNumber = int.Parse(Console.ReadLine());

int sum = firstNumber + secondNumber; // addind first number to second number
int divide = sum / thirdNumber; // dividing the suim of first two number by the third number
int multiply = divide * fourthNumber; // multiply the result of second operation by the fourth number

Console.WriteLine(multiply); // printing the result after the last operation

