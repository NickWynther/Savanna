using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class Antelope : Herbivore
    {
        public Antelope() : base(health:100, visionRange:5, maxSpeed:2 , symbol:(char)AnimalType.Antelope)
        {

        }
    }
}
