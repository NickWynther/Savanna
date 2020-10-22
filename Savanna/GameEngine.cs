using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class GameEngine
    {
        private Field _field;

        //private IConsole _console;
        private IAnimalFactory _animalFactory;
        private IAnimalManager _animalManager;
        private IHerbivoreManager _herbivoreManager;
        private ICarnivoreManager _carnivoreManager;
        private IView _view;

        public GameEngine(IAnimalFactory animalFactory, IAnimalManager animalmanager, 
            IHerbivoreManager herbivoreManager, ICarnivoreManager carnivoreManager, IView view)
        {
            _herbivoreManager = herbivoreManager;
            _carnivoreManager = carnivoreManager;
            _animalFactory = animalFactory;
            _animalManager = animalmanager;
            _view = view;
            _field = new();
        }

        private void Iteration()
        {
            _animalManager.LocateEnemies(_field);
            // animal locateFriend
            // herbivore Move
            // carnivore Move
            // view Display
        }
    }
}
