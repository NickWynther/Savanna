﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface IConsole
    {
        /// <summary>
        /// Gets a value indicating whether a key pressed is available in the input stream.
        /// </summary>
        public bool KeyAvailable();

        /// <summary>
        /// Obtain next key pressed by user.
        /// </summary>
        public ConsoleKey ConsoleKey();

        /// <summary>
        /// Set the position of the cursor.
        /// </summary>
        public void SetCursorPosition(Position position);

        /// <summary>
        /// Clear the console buffer
        /// </summary>
        public void Clear();

        /// <summary>
        /// Write the specified character.
        /// </summary>
        public void Write(char symbol);

        /// <summary>
        /// Gets or set the foreground color of the console.
        /// </summary>
        public ConsoleColor ForegroundColor { get; set ; }
    }
}
