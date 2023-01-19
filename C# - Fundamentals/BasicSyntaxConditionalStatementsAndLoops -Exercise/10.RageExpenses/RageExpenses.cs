int lostGame = int.Parse(Console.ReadLine());
double headsetPrice = double.Parse(Console.ReadLine());   
double mousePrice = double.Parse(Console.ReadLine()); 
double keyboardPrice = double.Parse(Console.ReadLine());  
double displayPrice = double.Parse(Console.ReadLine());

int trashedHeadset = 0;
int trashedMouse = 0;
int trashedKeyboard = 0;
int trashedDisplay = 0;



double keyboardTotalPrice = trashedKeyboard * keyboardPrice;
double mouseTotalPrice = trashedMouse * mousePrice;
double headsetTotalPrice = trashedHeadset * headsetPrice;
double displayTotalPrice = trashedDisplay * displayPrice;

double expenses = keyboardTotalPrice + mouseTotalPrice + headsetTotalPrice + displayTotalPrice;

Console.WriteLine($"Rage expenses: {expenses:f2}lv.");