using System;
using System.Collections.Generic;
using System.Text;
using Savanna;

namespace Savanna
{
    public class Rabbit : Herbivore
    {
        public Rabbit() : base(maxHealth: 20, visionRange: 2, breedingDistance: 4, maxSpeed: 4, AnimalType.Rabbit)
        {

        }
    }
}
