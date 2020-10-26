using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Savanna
{
    /// <summary>
    /// Position validator. 
    /// </summary>
    public class Validator : IPositionValidator
    {
        /// <summary>
        /// Check if position on field is taken by any animal.
        /// </summary>
        public bool PositionIsTaken(Field field, Position position)
            =>field.Animals.FirstOrDefault(a => a.Position.Equals(position)) != null;

        /// <summary>
        /// Check if position is out of field.
        /// </summary>
        public bool PositionIsOutOfField(Field field, Position position)
            => position.X >= field.Width || position.Y >= field.Height || position.X < 0 || position.Y < 0;

        /// <summary>
        /// Check if position on field is taken by carnivore.
        /// </summary>
        public bool PositionIsTakenByCarnivore(Field field, Position position )
            =>field.Carnivores.FirstOrDefault(c => c.Position.Equals(position)) != null;

        /// <summary>
        /// Check if position on field is taken by herbivore.
        /// </summary>
        public bool PositionIsTakenByHerbivore(Field field, Position position)
            => field.Herbivores.FirstOrDefault(h => h.Position.Equals(position)) != null;

    }
}
