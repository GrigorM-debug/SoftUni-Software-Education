using System;

namespace _04._Vacation_Books_List
{
    internal class VacationBooksList
    {
        static void Main(string[] args)
        {
            //Вход
            int pagesNumber = int.Parse(Console.ReadLine());
            int pagesForOneHour = int.Parse(Console.ReadLine());
            int daysToFinishTheBooks = int.Parse(Console.ReadLine());
            //Изчисления
            int totalTime = pagesNumber / pagesForOneHour;
            int neededHoursForDay = totalTime / daysToFinishTheBooks;
            Console.WriteLine(neededHoursForDay);
        }
    }
}
