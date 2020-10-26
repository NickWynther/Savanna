using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface ICarnivoreManager
    {
        /// <summary>
        /// Every carnivore on a field make move.
        /// </summary>
        public void Move(Field field);
    }
}
