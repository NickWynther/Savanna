using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class Lion : Carnivore
    {
        public Lion() : base(maxHealth:100, visionRange:6, maxSpeed:3, symbol:(char)AnimalType.Lion)
        {
            
        }
    }
}
