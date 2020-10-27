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
        /// Game start.
        /// Call GameSycle in a loop.
        /// </summary>
        /// <param name="speed">GameCycle speed in miliseconds</param>
        void Run(int speed);

        /// <summary>
        /// Make new game iteration. Handle user input. 
        /// </summary>
        /// <param name="speed">iteration speed in miliseconds</param>
        public void GameCycle(int speed);
    }
}
