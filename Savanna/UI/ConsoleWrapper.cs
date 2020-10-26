using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{

    /// <summary>
    /// Represent standart input/output for console application.
    /// </summary>
    public class ConsoleWrapper : IConsole
    {
        /// <summary>
        /// Gets a value indicating whether a key pressed is available in the input stream.
        /// </summary>
        public bool KeyAvailable() => Console.KeyAvailable;
 
        /// <summary>
        /// Obtain next key pressed by user.
        /// </summary>
        public ConsoleKey ConsoleKey() => Console.ReadKey(true).Key;
        

        /// <summary>
        /// Set the position of the cursor.
        /// </summary>
        public void SetCursorPosition(Position position) => Console.SetCursorPosition(position.X, position.Y);

        /// <summary>
        /// Clear the console buffer
        /// </summary>
        public void Clear() => Console.Clear();

        /// <summary>
        /// Write the specified character.
        /// </summary>
        public void Write(char symbol) => Console.Write(symbol);

        /// <summary>
        /// Gets or set the foreground color of the console.
        /// </summary>
        public ConsoleColor ForegroundColor { get => Console.ForegroundColor; set => Console.ForegroundColor = value; }
    }
}
