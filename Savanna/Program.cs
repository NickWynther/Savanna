using System;

namespace Savanna
{
    class Program
    {
        static void Main(string[] args)
        {
            new GameFactory().CreateGame().Run();
        }
    }
}
