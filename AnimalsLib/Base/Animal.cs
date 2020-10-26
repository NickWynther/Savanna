using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    /// <summary>
    /// Base class for every animal.
    /// </summary>
    public abstract class Animal
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="maxHealth">Max health value.</param>
        /// <param name="visionRange">Animal vision range.</param>
        /// <param name="breedingDistance">Minimal distance to other animal of same type where animals start breeding </param>
        /// <param name="maxSpeed">Animal max step distence in one iteration.</param>
        /// <param name="type">Enumeration with displayed symbol.</param>
        protected Animal(float maxHealth, int visionRange, int breedingDistance, int maxSpeed , AnimalType type)
        {
            Health = maxHealth;
            MaxHealth = maxHealth;
            VisionRange = visionRange;
            MaxSpeed = maxSpeed;
            AnimalType = type;
            BreedingDistance = breedingDistance;
        }

        public float Health { get; protected set; }
        public float MaxHealth { get; private set; }
        public bool Alive { get => Health > 0; }
        public bool HasEnemy { get => ClosestEnemy != null; } 
        public Animal ClosestEnemy { get; set; }
        public Animal ClosestPartner { get; set; }
        public int MatingCount { get; set; }
        public int VisionRange { get; private set; }
        public int BreedingDistance { get; private set; }
        public Position Position { get; set ; }
        public int MaxSpeed { get; private set; }
        public AnimalType AnimalType { get; private set; }
        public char Symbol { get => (char)AnimalType; }

        /// <summary>
        /// Move animal on field.
        /// </summary>
        /// <param name="step">value value for move</param>
        /// <returns>New position on the field.</returns>
        public Position MakeStep(Position step) => Position.Add(step);

        /// <summary>
        /// Decrease 0.5 healt 
        /// </summary>
        public void DecreaseHealth(float decreaseValue)
        {
            Health -= decreaseValue;
        }
    }
}
