using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class Antelope : Herbivore
    {
        public Antelope() : base(maxHealth:100, visionRange:5, breedingDistance:4, maxSpeed:2 , AnimalType.Antelope)
        {

        }
    }
}
