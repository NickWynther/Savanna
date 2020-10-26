using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    /// <summary>
    /// All animals behavior manager.
    /// </summary>
    public interface IAnimalManager
    {
        /// <summary>
        /// Locate closest enemy for every animal on field.
        /// </summary>
        /// <param name="field">Game field</param>
        void LocateEnemies(Field field);

        /// <summary>
        /// Remove all dead animals from field.
        /// </summary>
        void RemoveCorpses(Field field);

        /// <summary>
        /// Decrease health value for every animal on field.
        /// </summary>
        void DecreaseHealth(Field field , float decreaseValue);

        /// <summary>
        /// Locate closest partner for breeding.
        /// </summary>
        public void FindPartners(Field field);

        /// <summary>
        /// Check every animal if its mating count is equal to 3, create new animal on a field.
        /// </summary>
        public void GiveBirthToAnimal(Field field, IAnimalFactory animalFactory);
    }
}
