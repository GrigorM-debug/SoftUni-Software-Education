using BorderControl.Core;
using BorderControl.Core.Interfaces;

namespace BorderControl
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