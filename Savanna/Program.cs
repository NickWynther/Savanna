using Ninject;
using System;
using System.Reflection;

namespace Savanna
{
    class Program
    {
        static void Main(string[] args)
        {
            //Using GameFactory static method to create game
            ///GameFactory.CreateGame().Run();

            //Using Ninject Framework to create game
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Get<IGameEngine>().Run();
        }
    }
}
