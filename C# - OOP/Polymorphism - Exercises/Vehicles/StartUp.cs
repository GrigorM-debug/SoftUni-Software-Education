using Vehicles.Core;
using Vehicles.Core.Interfaces;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}