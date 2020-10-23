using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface IAnimalFactory
    {
        public Animal Create(Field field, AnimalType type);
    }
}
