using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class Animal : IAnimal
    {
        public float Health { get; set; }
        public bool Alive { get => Health > 0; }
        public bool IsHerbivore { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public IAnimal ClosestEnemy { get; set; }
        public IAnimal ClosestFriend { get; set; }
        public int MatingCount { get; set; }
        
    }
}
