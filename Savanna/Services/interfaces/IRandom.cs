using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface IRandom
    {
        public int Get(int fromInclusive, int toInclusive);
        public int Get(int toExclusive);
        public Position GetRandomStep(int speed);

    }
}
