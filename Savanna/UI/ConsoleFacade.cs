using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class ConsoleFacade : IConsole
    {
        public bool KeyAvailable() => Console.KeyAvailable;
 
        public ConsoleKey ConsoleKey() => Console.ReadKey(true).Key;
           
        public void SetCursorPosition(Position position) => Console.SetCursorPosition(position.X, position.Y);

        public void Clear() => Console.Clear();

        public void Write(char symbol) => Console.Write(symbol);

        public ConsoleColor ForegroundColor { get => Console.ForegroundColor; set => Console.ForegroundColor = value; }
    }
}
