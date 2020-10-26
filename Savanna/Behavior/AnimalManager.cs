using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Savanna
{
    /// <summary>
    /// All animals behavior manager.
    /// </summary>
    public class AnimalManager : IAnimalManager
    {
        private ICalculations _calculations;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="calculations">Game math</param>
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


        /// <summary>
        /// Remove all dead animals from field.
        /// </summary>
        public void RemoveCorpses(Field field) 
            =>field.Animals.RemoveAll(a => a.Alive == false);


        /// <summary>
        /// Decrease health value for every animal on field.
        /// </summary>
        public void DecreaseHealth(Field field , float decreaseValue)
            => field.Animals.ForEach(animal => animal.DecreaseHealth(decreaseValue));

        /// <summary>
        /// Locate closest partner for breeding.
        /// </summary>
        public void FindPartners(Field field)
        {
            foreach (var currentAnimal in field.Animals)
            {
                var partnerList = field.Animals.Where(a => a.AnimalType == currentAnimal.AnimalType).ToList();
                partnerList.Remove(currentAnimal);
                Animal newClosestParter = null;
                var minDistance = double.MaxValue;
                foreach (var potentialPartner in partnerList)
                {
                    var distance = _calculations.Distance(currentAnimal, potentialPartner);
                    if (distance <= currentAnimal.BreedingDistance && distance < minDistance)
                    {
                        minDistance = distance;
                        newClosestParter = potentialPartner;
                    }
                }

                CountMatings(currentAnimal, newClosestParter);
            }
        }

        /// <summary>
        /// Check if partner is stil same. Calculate mating count. 
        /// </summary>
        private static void CountMatings(Animal currentAnimal, Animal newClosestParter)
        {
            if (newClosestParter == null)
            {
                currentAnimal.ClosestPartner = null;
                currentAnimal.MatingCount = 0;
            }
            else if (currentAnimal.ClosestPartner == newClosestParter)
            {
                currentAnimal.MatingCount += 1;
            }
            else
            {
                currentAnimal.ClosestPartner = newClosestParter;
                currentAnimal.MatingCount = 1;
            }
        }

        /// <summary>
        /// Check every animal if its mating count is equal to 3, create new animal on a field.
        /// </summary>
        public void GiveBirthToAnimal(Field field, IAnimalFactory animalFactory)
        {
            foreach(var animal in field.Animals)
            {
                if (animal.MatingCount == 3)
                {
                    animal.MatingCount = 0;

                    if (animal.ClosestPartner.ClosestPartner == animal)
                    {
                        animal.ClosestPartner.MatingCount = 0;
                    }

                    animalFactory.Create(field, animal.AnimalType);
                }
            }
        }
    }
}
