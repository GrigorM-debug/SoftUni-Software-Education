using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Core.Interfaces;
using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony.Core
{
    internal class Engine : IEngine
    {
        public void Run()
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICallable callable;

            foreach (string phoneNumber in phoneNumbers)
            {
                if(phoneNumber.Length == 10)
                {
                    callable = new Smartphone();
                }
                else
                {
                    callable= new StationaryPhone();
                }

                try
                {
                    Console.WriteLine(callable.Call(phoneNumber));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            IBrowsable browsable = new Smartphone();

            foreach (string url in urls)
            {
                try
                {
                    Console.WriteLine(browsable.Browse(url));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
