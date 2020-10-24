using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public interface IConsole
    {
        bool KeyAvailable();
        ConsoleKey ConsoleKey();
        void SetCursorPosition(Position position);
        void Clear();
        void Write(char symbol);

    }
}
