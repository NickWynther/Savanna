using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface IRandom
    {
        /// <summary>
        /// Get random integer between a specified inclusive lower bound and a specifed inclusive upper bound.
        /// </summary>
        public int Get(int fromInclusive, int toInclusive);

        /// <summary>
        /// Get random integer between 0 and a specifed inclusive upper bound.
        /// </summary>
        public int Get(int toExclusive);

        /// <summary>
        ///  Create random animal step with specified speed.
        /// </summary>
        public Position GetRandomStep(int speed);

    }
}
