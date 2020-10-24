using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Savanna
{
    public class Random : IRandom
    {
        public int Get(int fromInclusive , int toInclusive) 
            => RandomNumberGenerator.GetInt32(fromInclusive, toInclusive + 1);
        public int Get(int toExclusive)
           => RandomNumberGenerator.GetInt32(0, toExclusive);

        public Position GetRandomStep(int speed)
            => new Position() { 
                X = Get(-speed, speed), 
                Y = Get(-speed, speed) 
            };
    }
}
