using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class ConsoleFacade 
    {
        public bool KeyAvailable()
            => Console.KeyAvailable;
 
        public ConsoleKey ConsoleKey()
            => Console.ReadKey(true).Key;
           
        public void SetCursorPosition(Position position)
            => Console.SetCursorPosition(position.X, position.Y);
        
    }
}
