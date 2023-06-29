using BorderControl.Core.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IIdentifiable> list = new();
            List<IBirthable> celebrate = new();

            //string input;

            //while((input = Console.ReadLine()) != "End") 
            //{
            //    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //    if(tokens.Length == 3) 
            //    {
            //        string name = tokens[0];
            //        int age = int.Parse(tokens[1]);
            //        string id = tokens[2];

            //        IIdentifiable citizen = new Citizen(name, age, id);

            //        list.Add(citizen);
            //    }
            //    else
            //    {
            //        string model = tokens[0];
            //        string id = tokens[1];

            //        IIdentifiable robot = new Robot(model, id);

            //        list.Add(robot);
            //    }
            //}

            //string invalidID = Console.ReadLine();

            //foreach(var item in list)
            //{
            //    if(item.Id.EndsWith(invalidID))
            //    {
            //        Console.WriteLine(item.Id);
            //    }
            //}

            string input;
            while((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Citizen")
                {
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthDate = tokens[4];

                    IBirthable citizen = new Citizen(name, age, id, birthDate); 

                    celebrate.Add(citizen);
                }
                else if (tokens[0] == "Robot")
                {
                    string model = tokens[1];
                    string id = tokens[2];

                    IIdentifiable robot = new Robot(model, id);

                    list.Add(robot);
                }
                else if (tokens[0]  == "Pet")
                {
                    string name = tokens[1];
                    string birthDate = tokens[2];

                    IBirthable pet = new Pet(name, birthDate);

                    celebrate.Add(pet);
                }
            }

            string year = Console.ReadLine();

            foreach(var item in celebrate)
            {
                if (item.BirthDate.EndsWith(year))
                {
                    Console.WriteLine(item.BirthDate);
                }
            }
        }
    }
}
