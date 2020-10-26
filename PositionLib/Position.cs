using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    /// <summary>
    /// This class represents a pair of coordinates (x,y)
    /// </summary>
    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position()
        {

        }

        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Create copy
        /// </summary>
        public Position Clone()
        {
            return new Position(X, Y);
        }

        /// <summary>
        /// Apply (add) step for current position.
        /// </summary>
        public Position Add(Position step)
        {
            X += step.X;
            Y += step.Y;
            return this;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            Position pos = (Position)obj;
            return (this.X == pos.X && this.Y == pos.Y);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}
