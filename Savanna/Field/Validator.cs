using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Savanna
{
    public class Validator : IPositionValidator
    {
        public bool PositionIsTaken(Field field, Position position)
            =>field.Animals.FirstOrDefault(a => a.Position.Equals(position)) != null;

        public bool PositionIsOutOfField(Field field, Position position)
            => position.X >= field.Width || position.Y >= field.Height || position.X < 0 || position.Y < 0;

        public bool PositionIsTakenByCarnivore(Field field, Position position )
            =>field.Carnivores.FirstOrDefault(c => c.Position.Equals(position)) != null;

        public bool PositionIsTakenByHerbivore(Field field, Position position)
            => field.Herbivores.FirstOrDefault(h => h.Position.Equals(position)) != null;



        public bool ValidateMove(Field field, Animal animal, int stepX, int stepY )
        {
            var newPosition = new Position(animal.Position.X + stepX, animal.Position.Y + stepY);
            if (PositionIsOutOfField(field, newPosition)) return false;
            return  PositionIsTaken(field, newPosition) == false || animal.Position.Equals(newPosition);
        }
    }
}
