using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    /// <summary>
    /// Base class for herbivore animal.
    /// </summary>
    public abstract class Herbivore : Animal
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="maxHealth">Max health value.</param>
        /// <param name="visionRange">Animal vision range.</param>
        /// <param name="breedingDistance">Minimal distance to other animal of same type where animals start breeding </param>
        /// <param name="maxSpeed">Animal max step distence in one iteration.</param>
        /// <param name="type">Enumeration with displayed symbol.</param>
        public Herbivore(float maxHealth, int visionRange, int breedingDistance, int maxSpeed, AnimalType type  ) : 
            base(maxHealth, visionRange, breedingDistance, maxSpeed, type)
        {

        }

        /// <summary>
        /// Set health value to zero. (Alive property equals to false)
        /// </summary>
        public void Die()
        {
            Health = 0;
        }
    }
}
