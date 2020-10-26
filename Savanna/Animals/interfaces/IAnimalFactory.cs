using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface IAnimalFactory
    {
        /// <summary>
        /// Create new animal.
        /// </summary>
        /// <param name="field">Field where to place new animal.</param>
        /// <param name="type">Animal specie</param>
        public Animal Create(Field field, AnimalType type);
    }
}
