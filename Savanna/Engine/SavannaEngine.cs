using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Savanna
{
    /// <summary>
    /// Savanna game engine
    /// </summary>
    public class SavannaEngine : IGameEngine
    {
        private Field _field;
        private IConsole _console;
        private IAnimalFactory _animalFactory;
        private IAnimalManager _animalManager;
        private IHerbivoreManager _herbivoreManager;
        private ICarnivoreManager _carnivoreManager;
        private IView _view;

        /// <summary>
        /// Default constructor
        /// </summary>
        public SavannaEngine(IAnimalFactory animalFactory, IAnimalManager animalmanager, 
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

        /// <summary>
        /// Game start.
        /// Make new iteration every second. Handle user input.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                try
                {
                    HandlePlayerCommands();
                    Iteration();
                    Thread.Sleep(1000);
                }
                catch 
                {
                    //display error
                }
            }
        }

        /// <summary>
        /// Add new animals on field if user press corresponding buttons.
        /// </summary>
        private void HandlePlayerCommands()
        {
            while (_console.KeyAvailable())
            {
                AnimalType type = (AnimalType)char.Parse(_console.ConsoleKey().ToString());
                var newAnimal = _animalFactory.Create(_field, type);
                _field.Animals.Add(newAnimal);
            }
        }

        /// <summary>
        /// Game basic iteration.
        /// </summary>
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
