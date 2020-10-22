using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface IAnimal
    {
        float Health { get; set; }
        bool Alive { get;}

        int PosX { get; set; }

        int PosY { get; set; }

        bool IsHerbivore { get; set; }

        IAnimal ClosestEnemy { get; set; }

        IAnimal ClosestFriend { get; set; }

        int MatingCount { get; set; }

    }
}
