int peopleCnt = int.Parse(Console.ReadLine());
string typeOfPeople = Console.ReadLine();  
string day = Console.ReadLine();

decimal pricePerPerson = 0.0m;

switch (day)
{
    case "Friday":
        switch (typeOfPeople)
        {
            case "Students":
                pricePerPerson = 8.45m;
                break;
            case "Business":
                pricePerPerson = 10.90m;
                break;
            case "Regular":
                pricePerPerson = 15m;
                break;
        }
        break;
    case "Saturday":
        switch (typeOfPeople)
        {
            case "Students":
                pricePerPerson = 9.80m;
                break;
            case "Business":
                pricePerPerson = 15.60m;
                break;
            case "Regular":
                pricePerPerson = 20m;
                break;
        }
        break;
    case "Sunday":
        switch (typeOfPeople)
        {
            case "Students":
                pricePerPerson = 10.46m;
                break;
            case "Business":
                pricePerPerson = 16m;
                break;
            case "Regular":
                pricePerPerson = 22.50m;
                break;
        }
        break;
}
decimal totalPrice = peopleCnt * pricePerPerson;

if (typeOfPeople == "Students" && peopleCnt >= 30)
{
    totalPrice = totalPrice - totalPrice * 0.15m;
}
else if (typeOfPeople == "Business" && peopleCnt >= 100)
{
    totalPrice = (peopleCnt - 10) * pricePerPerson; // 10 people will stat for free
}
else if (typeOfPeople == "Regular" && peopleCnt >= 10 && peopleCnt <=20)
{
    totalPrice = totalPrice - totalPrice * 0.05m;
}

Console.WriteLine($"Total price: {totalPrice:f2}");
