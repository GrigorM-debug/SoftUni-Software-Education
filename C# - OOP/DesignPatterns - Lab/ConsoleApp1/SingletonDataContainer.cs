using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private IDictionary<string, int> _capitals = new Dictionary<string, int>();

        private static SingletonDataContainer instance = new SingletonDataContainer();  
        public SingletonDataContainer()
        {
            Console.WriteLine("Initializing singleton object");

            var elements = File.ReadAllLines("capitals.txt");

            for(int i = 0; i < elements.Length; i+=2)
            {
                _capitals.Add(elements[i], int.Parse(elements[i+1]));
            }
        }

        public static SingletonDataContainer Instance => instance;

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }
    }
}
