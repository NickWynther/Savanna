using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface IPositionValidator
    {
        bool PositionIsTaken(Field field, Position position);

        bool ValidateMove(Field field, Animal animal, int stepX, int stepY);

        bool PositionIsOutOfField(Field field, Position position);

        bool PositionIsTakenByCarnivore(Field field, Position position);

        public bool PositionIsTakenByHerbivore(Field field, Position position);

    }
}
