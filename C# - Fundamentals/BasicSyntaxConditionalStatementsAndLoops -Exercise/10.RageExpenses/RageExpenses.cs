int lostGame = int.Parse(Console.ReadLine());
decimal headsetPrice = decimal.Parse(Console.ReadLine());   
decimal mousePrice = decimal.Parse(Console.ReadLine()); 
decimal keyboardPrice = decimal.Parse(Console.ReadLine());  
decimal displayPrice = decimal.Parse(Console.ReadLine());

decimal trashedHeadset = (lostGame / 2) * headsetPrice;
decimal trashedMouse = (lostGame / 3) * mousePrice;
decimal trashedKeyboard = (lostGame / 6) * keyboardPrice;
decimal trashedDisplay = (lostGame / 12) * displayPrice;

decimal expenses = trashedHeadset + trashedMouse + trashedKeyboard + trashedDisplay; 
Console.WriteLine($"Rage expenses: {expenses:f2} lv.");