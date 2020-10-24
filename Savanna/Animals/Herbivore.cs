using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public abstract class Herbivore : Animal
    {
        public Herbivore(float maxHealth, int visionRange, int breedingDistance, int maxSpeed, AnimalType type  ) : 
            base(maxHealth, visionRange, breedingDistance, maxSpeed, type)
        {

        }

        public void Die()
        {
            Health = 0;
        }

    }
}
