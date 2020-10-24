using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Savanna
{
    /// <summary>
    /// Game random generator.
    /// </summary>
    public class Random : IRandom
    {

        /// <summary>
        /// Get random integer between a specified inclusive lower bound and a specifed inclusive upper bound.
        /// </summary>
        public int Get(int fromInclusive , int toInclusive) 
            => RandomNumberGenerator.GetInt32(fromInclusive, toInclusive + 1);

        /// <summary>
        /// Get random integer between 0 and a specifed inclusive upper bound.
        /// </summary>
        public int Get(int toExclusive)
           => RandomNumberGenerator.GetInt32(0, toExclusive);

        
        /// <summary>
        ///  Create random animal step with specified speed.
        /// </summary>
        public Position GetRandomStep(int speed)
            => new Position() { 
                X = Get(-speed, speed), 
                Y = Get(-speed, speed) 
            };
    }
}
