using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class Calculations
    {
        public double Distance(int x1, int x2, int y1, int y2) 
            => Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));

        public double Distance(IAnimal current, IAnimal target)
            => Distance(current.Position.X, target.Position.X, current.Position.Y, target.Position.Y);
    }
}
