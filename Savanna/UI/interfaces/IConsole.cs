using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface IConsole
    {
        public bool KeyAvailable();
        public ConsoleKey ConsoleKey();
        public void SetCursorPosition(Position position);

    }
}
