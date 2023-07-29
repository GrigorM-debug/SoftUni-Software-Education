using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.IO.Contracts;

namespace UniversityCompetition.IO
{
    public class Writer : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            //Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(message);

            //Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
