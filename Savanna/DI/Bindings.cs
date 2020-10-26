using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    /// <summary>
    /// Define binding for application.
    /// </summary>
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IAnimalFactory>().To<AnimalFactory>();
            Bind<IAnimalManager>().To<AnimalManager>();
            Bind<ICalculations>().To<Calculations>();
            Bind<ICarnivoreManager>().To<CarnivoreManager>();
            Bind<IConsole>().To<ConsoleWrapper>();
            Bind<IGameEngine>().To<SavannaEngine>();
            Bind<IHerbivoreManager>().To<HerbivoreManager>();
            Bind<IPositionValidator>().To<Validator>();
            Bind<IRandom>().To<RandomWrapper>();
            Bind<IView>().To<GameView>();
        }
    }
}
