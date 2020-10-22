using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface IAnimal
    {
        float Health { get; set; }
        bool Alive { get; }
        Position Position { get; set; }
        bool IsHerbivore { get; set; }
        IAnimal ClosestEnemy { get; set; }
        IAnimal ClosestFriend { get; set; }
        int MatingCount { get; set; }
        public int VisionRange { get; set; }
        public int MaxSpeed { get; set; }

    }
}
