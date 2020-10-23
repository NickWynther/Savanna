using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public abstract class Animal
    {
        protected Animal(float health, int visionRange, int maxSpeed)
        {
            Health = health;
            VisionRange = visionRange;
            MaxSpeed = maxSpeed;
        }

        public float Health { get; protected set; }
        public bool Alive { get => Health > 0; }
        public Animal ClosestEnemy { get; set; }
        public Animal ClosestFriend { get; set; }
        public int MatingCount { get; set; }
        public int VisionRange { get; private set; }
        public Position Position { get; set ; }
        public int MaxSpeed { get; private set; }
        public void MakeStep(int x, int y)
        {
            Position.X += x;
            Position.Y += y;
        }
    }
}
