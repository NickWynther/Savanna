using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Savanna
{
    public class AnimalManager : IAnimalManager
    {
        private ICalculations _calculations;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="calculations"></param>
        public AnimalManager(ICalculations calculations)
        {
            _calculations = calculations;
        }

        /// <summary>
        /// Locate closest enemy for every animal on field.
        /// </summary>
        /// <param name="field">Game field</param>
        public void LocateEnemies(Field field)
        {
            var carnivores = field.Carnivores.Cast<Animal>();
            var herbivores = field.Herbivores.Cast<Animal>();
            LocateEnemiesForOneSpecie(carnivores, herbivores);
            LocateEnemiesForOneSpecie(herbivores, carnivores);
        }

        /// <summary>
        /// For every animal in 'FriendsList' locate closest animal in 'EnemiesList'
        /// </summary>
        private void LocateEnemiesForOneSpecie(IEnumerable<Animal> FriendsList , IEnumerable<Animal> EnemiesList)
        {
            foreach (var currentAnimal in FriendsList)
            {
                currentAnimal.ClosestEnemy = null;
                var minDistance = double.MaxValue;
                
                foreach (var enemy in EnemiesList)
                {
                    var distance = _calculations.Distance(currentAnimal, enemy);
                    if (distance <= currentAnimal.VisionRange && distance < minDistance)
                    {
                        minDistance = distance;
                        currentAnimal.ClosestEnemy = enemy;
                    }
                }
            }
        }

        public void RemoveCorpses(Field field) 
            =>field.Animals.RemoveAll(a => a.Alive == false);

    }
}
