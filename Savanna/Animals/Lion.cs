using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class Lion : Carnivore
    {
        public Lion() : base(maxHealth:100, visionRange:6, breedingDistance:2, maxSpeed:3, AnimalType.Lion)
        {
            
        }
    }
}
