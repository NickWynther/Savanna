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

        public void DecreaseHealth(Field field)
            => field.Animals.ForEach(animal => animal.DecreaseHealth());

        public void FindPartners(Field field)
        {
            foreach (var currentAnimal in field.Animals)
            {
                //same with reflection ? currentAnimal.GetType().Name

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

                if (currentAnimal.ClosestPartner == newClosestParter && newClosestParter!= null)
                {
                    currentAnimal.MatingCount += 1;
                }
                else if (newClosestParter!=null)
                {
                    currentAnimal.ClosestPartner = newClosestParter;
                    currentAnimal.MatingCount = 1;
                }
                else
                {
                    currentAnimal.ClosestPartner = null;
                    currentAnimal.MatingCount = 0;
                }
            }
        }

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
