using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class GameView : IView
    {
        private IConsole _console;
        public GameView(IConsole console)
        {
            _console = console;
        }

        public void Display(Field field)
        {
            _console.Clear();
            field.Animals.ForEach(animal => DisplayAnimal(animal));
            //show stats
        }

        private void DisplayAnimal(Animal animal)
        {
            _console.SetCursorPosition(animal.Position);
            _console.Write(animal.Symbol);
        }

    }
}
