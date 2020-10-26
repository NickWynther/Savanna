using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface IHerbivoreManager
    {
        /// <summary>
        /// Every herbivore on a field make move.
        /// </summary>
        public void Move(Field field);
    }
}
