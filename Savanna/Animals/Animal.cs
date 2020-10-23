using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public abstract class Animal /*: IAnimal*/
    {
        protected Animal(float health, bool isHerbivore, int visionRange, int maxSpeed)
        {
            Health = health;
            IsHerbivore = isHerbivore;
            VisionRange = visionRange;
            MaxSpeed = maxSpeed;
        }

        public float Health { get; private set; }
        public bool Alive { get => Health > 0; }
        public bool IsHerbivore { get; private set; }
        public Animal ClosestEnemy { get; set; }
        public Animal ClosestFriend { get; set; }
        public int MatingCount { get; set; }
        public int VisionRange { get; private set; }
        public Position Position { get; set ; }
        public int MaxSpeed { get; private set; }
    }
}
