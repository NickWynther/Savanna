using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class AnimalManager : IAnimalManager
    {
        private ICalculations _calc;

        public AnimalManager(ICalculations calc)
        {
            _calc = calc;
        }

        public void LocateEnemies(Field field)
        {
            LocateEnemiesForOneSpecie(field.Carnivores, field.Herbivores);
            LocateEnemiesForOneSpecie(field.Herbivores, field.Carnivores);
        }

        private void LocateEnemiesForOneSpecie(List<Animal> FriendsList , List<Animal> EnemiesList)
        {
            foreach (var currentAnimal in FriendsList)
            {
                currentAnimal.ClosestEnemy = null;
                var minDistance = double.MaxValue;

                foreach (var enemy in EnemiesList)
                {
                    var distance = _calc.Distance(currentAnimal, enemy);
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
