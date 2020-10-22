using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class Antelope : Animal
    {
        public Antelope()
        {
            IsHerbivore = true;
            VisionRange = 5;
            MaxSpeed = 2;
        }
    }
}
