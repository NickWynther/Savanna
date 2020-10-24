using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    /// <summary>
    /// Game 
    /// </summary>
    public interface IGameEngine
    {
        /// <summary>
        /// Start game.
        /// </summary>
        /// <param name="speed">iteration speed in miliseconds</param>
        void Run(int speed);
    }
}
