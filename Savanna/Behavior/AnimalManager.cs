using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Savanna
{
    public class AnimalManager : IAnimalManager
    {
        private ICalculations _calculations;

        public AnimalManager(ICalculations calculations)
        {
            _calculations = calculations;
        }

        public void LocateEnemies(Field field)
        {
            LocateEnemiesForOneSpecie(field.Carnivores.OfType<Animal>(), field.Herbivores.OfType<Animal>());
            LocateEnemiesForOneSpecie(field.Herbivores.OfType<Animal>(), field.Carnivores.OfType<Animal>());
        }

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
    }
}
