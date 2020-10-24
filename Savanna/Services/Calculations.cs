using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class Calculations : ICalculations
    {
        public double Distance(int x1, int x2, int y1, int y2) 
            => Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));

        public double Distance(Position current, Position target)
            => Distance(current.X, target.X, current.Y, target.Y);

        public double Distance(Animal current, Animal target)
            => Distance(current.Position, target.Position);
    }
}
