﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class Lion : Animal
    {
        public Lion()
        {
            IsHerbivore = false;
            VisionRange = 6;
            MaxSpeed = 3;
        }
    }
}