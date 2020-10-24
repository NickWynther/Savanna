using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Savanna
{
    public class GameEngine
    {
        private Field _field;

        private IConsole _console;
        private IAnimalFactory _animalFactory;
        private IAnimalManager _animalManager;
        private IHerbivoreManager _herbivoreManager;
        private ICarnivoreManager _carnivoreManager;
        private IView _view;

        public GameEngine(IAnimalFactory animalFactory, IAnimalManager animalmanager, 
            IHerbivoreManager herbivoreManager, ICarnivoreManager carnivoreManager, IView view , IConsole console)
        {
            _herbivoreManager = herbivoreManager;
            _carnivoreManager = carnivoreManager;
            _animalFactory = animalFactory;
            _animalManager = animalmanager;
            _console = console;
            _view = view;
            _field = new();
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    while (_console.KeyAvailable())
                    {
                        AnimalType type = (AnimalType)char.Parse(_console.ConsoleKey().ToString());
                        var newAnimal = _animalFactory.Create(_field, type);
                        _field.Animals.Add(newAnimal);
                    }

                    Iteration();
                    Thread.Sleep(1000);
                }
                catch 
                {
                    //display error
                }
            }
        }

        private void Iteration()
        {
            _animalManager.LocateEnemies(_field);
            _herbivoreManager.Move(_field);
            _carnivoreManager.Move(_field);
            _animalManager.RemoveCorpses(_field);
            // animal locateFriend for breeding
            _view.Display(_field);
        }
    }
}
