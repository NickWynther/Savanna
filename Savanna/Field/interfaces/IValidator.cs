using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface IValidator
    {
        bool PositionIsTaken(Field field, Position position);
    }
}
