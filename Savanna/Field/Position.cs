using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

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
