﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    /// <summary>
    /// Lion animal.
    /// </summary>
    public class Lion : Carnivore
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Lion() : base(maxHealth:100, visionRange:6, breedingDistance:2, maxSpeed:3, AnimalType.Lion)
        {
            
        }
    }
}
