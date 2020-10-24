using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public abstract class Herbivore : Animal
    {
        public Herbivore(float health, int visionRange, int maxSpeed, char symbol  ) : 
            base(health, visionRange, maxSpeed, symbol)
        {

        }

        public void Die()
        {
            Health = 0;
        }

    }
}
