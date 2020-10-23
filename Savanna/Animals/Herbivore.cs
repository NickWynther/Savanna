using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public abstract class Herbivore : Animal
    {
        public Herbivore(float health , int visionRange , int maxSpeed ) : 
            base(health, visionRange, maxSpeed)
        {

        }

        public void Die()
        {
            Health = 0;
        }

    }
}
