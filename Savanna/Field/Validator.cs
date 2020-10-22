using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Savanna
{
    public class Validator : IValidator
    {
        public bool PositionIsTaken(Field field, Position position)
            =>field.Animals.FirstOrDefault(a => a.Position.X == position.X && a.Position.Y == position.Y) != null;
    }
}
