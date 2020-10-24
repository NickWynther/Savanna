using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface IAnimalManager
    {
        void LocateEnemies(Field field);
        void RemoveCorpses(Field field);
        void DecreaseHealth(Field field);
    }
}
