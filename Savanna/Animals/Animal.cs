using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public abstract class Animal : IAnimal
    {
        public float Health { get; set; }
        public bool Alive { get => Health > 0; }
        public bool IsHerbivore { get; set; }
        public IAnimal ClosestEnemy { get; set; }
        public IAnimal ClosestFriend { get; set; }
        public int MatingCount { get; set; }
        public int VisionRange { get; set; }
        public Position Position { get; set ; }
        public int MaxSpeed { get; set; }
    }
}
