using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    /// <summary>
    /// Base class for carnivores
    /// </summary>
    public abstract class Carnivore : Animal
    {
        public Carnivore(float maxHealth, int visionRange, int breedingDistance, int maxSpeed , AnimalType type) :
           base(maxHealth, visionRange, breedingDistance, maxSpeed , type)
        {
            
        }

        /// <summary>
        /// Try to eat herbivore. If current animal is not in the same position on a field 
        /// with victim InvalidOperationException is thrown. 
        /// Method increase health value for current animal to maximum. And decrease victim helath value to zero. 
        ///(victim.Alive equals to false)
        /// </summary>
        /// <param name="victim">An animal to be eaten</param>
        public void Eat(Herbivore victim)
        {
            if (!Position.Equals(victim.Position))
            {
                throw new InvalidOperationException("Hunter and victim should be in the same place");
            }

            victim.Die();
            Health = MaxHealth;
        }
    }
}
