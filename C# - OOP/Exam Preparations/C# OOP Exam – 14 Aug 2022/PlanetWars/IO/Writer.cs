﻿using PlanetWars.IO.Contracts;
using System;

namespace PlanetWars.IO
{
    public class Writer : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.ForegroundColor= ConsoleColor.Green;

            Console.WriteLine(message);

            Console.ForegroundColor= ConsoleColor.White;
        }
    }
}
