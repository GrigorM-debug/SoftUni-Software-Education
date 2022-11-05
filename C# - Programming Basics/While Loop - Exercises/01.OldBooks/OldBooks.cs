using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            //запазваме любимата книга на Ани 
            string favouriteBook = Console.ReadLine();

            int count = 0; //броя книги, които сме прегледали в търсене на любимата
            string input = Console.ReadLine();

            //създаваме цикъл, в който всеки път ще четем заглавието на нова книга
            //   => докато не минем през всички книги (докато не получим: "No More Books".)
            //   => докато не намерим любимата книга 

            while (input != "No More Books")
            {
                if (input == favouriteBook)
                {
                    //Ако сме намерили книгата:
                    Console.WriteLine($"You checked {count} books and found it.");
                    break;
                }

                count++;
                input = Console.ReadLine();
            }

            //Ако не сме намерили книгата: 
            if (input == "No More Books")
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {count} books.");
            }



        }
    }
}