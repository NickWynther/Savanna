using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface IAnimalFactory
    {
        public IAnimal Create(Field field, AnimalType type);
    }
}
