using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface IPositionValidator
    {
        /// <summary>
        /// Check if position on field is taken by any animal.
        /// </summary>
        public bool PositionIsTaken(Field field, Position position);

        /// <summary>
        /// Check if position is out of field.
        /// </summary>
        public bool PositionIsOutOfField(Field field, Position position);
        /// <summary>
        /// Check if position on field is taken by carnivore.
        /// </summary>
        public bool PositionIsTakenByCarnivore(Field field, Position position);

        /// <summary>
        /// Check if position on field is taken by herbivore.
        /// </summary>
        public bool PositionIsTakenByHerbivore(Field field, Position position);
    }
}
