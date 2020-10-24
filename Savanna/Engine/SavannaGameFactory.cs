using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class SavannaGameFactory
    {
        /// <summary>
        /// Create SavannaEngine with injected dependecies.
        /// </summary>
        public static SavannaEngine CreateGame()
        {
            IConsole console = new ConsoleFacade();
            IRandom random = new Random();
            ICalculations calculations = new Calculations();
            IPositionValidator validator = new Validator();
            IView view = new GameView(console);
            IAnimalFactory animalFactory = new AnimalFactory(random,validator);
            IAnimalManager animalManager = new AnimalManager(calculations);
            IHerbivoreManager herbivoreManager = new HerbivoreManager(random, validator, calculations);
            ICarnivoreManager carnivoreManager = new CarnivoreManager(random, validator, calculations);

            return new SavannaEngine(animalFactory, animalManager, herbivoreManager, carnivoreManager, view, console);
        }
    }
}
