using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    /// <summary>
    /// Antelope animal.
    /// </summary>
    public class Antelope : Herbivore
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Antelope() : base(maxHealth:100, visionRange:5, breedingDistance:4, maxSpeed:2 , AnimalType.Antelope)
        {

        }
    }
}
