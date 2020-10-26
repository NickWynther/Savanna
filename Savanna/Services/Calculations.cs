using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    /// <summary>
    /// Game math.
    /// </summary>
    public class Calculations : ICalculations
    {
        /// <summary>
        /// Calculate distance between two ponts represnted with Xi and Yi
        /// </summary>
        private double Distance(int x1, int x2, int y1, int y2) 
            => Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));

        /// <summary>
        /// Calculate distance between two Positions.
        /// </summary>
        public double Distance(Position current, Position target)
            => Distance(current.X, target.X, current.Y, target.Y);

        /// <summary>
        /// Calculate distance between two Animals.
        /// </summary>
        public double Distance(Animal current, Animal target)
            => Distance(current.Position, target.Position);
    }
}
