using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface ICalculations
    {
        public double Distance(Animal current, Animal target);
        public double Distance(Position current, Position target);
    }
}
