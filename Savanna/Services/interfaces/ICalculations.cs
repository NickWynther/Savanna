using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    /// <summary>
    /// Game math.
    /// </summary>
    public interface ICalculations
    {
        /// <summary>
        /// Calculate distance between two Positions.
        /// </summary>
        public double Distance(Position current, Position target);

        /// <summary>
        /// Calculate distance between two Animals.
        /// </summary>
        public double Distance(Animal current, Animal target);
           
    }
}
