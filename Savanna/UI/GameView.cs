using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class GameView : IView
    {
        private IConsole _console;
        private bool _boardersAreDrawn;
        private const char _borderSymbol = '#';
        private List<Position> _drawnAnimals;
        public GameView(IConsole console)
        {
            _console = console;
            _boardersAreDrawn = false;
            _drawnAnimals = new List<Position>();
        }

        public void Display(Field field)
        {
            if (!_boardersAreDrawn)
            {
                DrawBorders(field);
            }
            ClearDrawnAnimals();
            DrawAnimals(field);
            SavePositions(field);
            //show stats
        }

        private void DrawAnimals(Field field)
            => field.Animals.ForEach(animal => DisplayAnimal(animal));

        private void SavePositions(Field field)
            =>field.Animals.ForEach(animal => _drawnAnimals.Add(animal.Position.Clone()));

        private void DrawBorders(Field field)
        {
            DrawRightBorder(field);
            DrawBottomBorder(field);
            _boardersAreDrawn = true;
        }

        private void ClearDrawnAnimals()
        { 
            _drawnAnimals.ForEach(p => HidePosition(p));
            _drawnAnimals.Clear();
        }

        private void HidePosition(Position position)
        {
            _console.SetCursorPosition(position);
            _console.Write(' ');
        }

        private void DrawBottomBorder(Field field)
        {
            for (var pos = new Position(0, field.Height); pos.X <= field.Width; pos.X++)
            {
                _console.SetCursorPosition(pos);
                _console.Write(_borderSymbol);
            }
        }

        private void DrawRightBorder(Field field)
        {
            for (var pos = new Position(field.Width, 0); pos.Y <= field.Height; pos.Y++)
            {
                _console.SetCursorPosition(pos);
                _console.Write(_borderSymbol);
            }
        }

        private void DisplayAnimal(Animal animal)
        {
            _console.SetCursorPosition(animal.Position);
            _console.ForegroundColor = animal is Herbivore ? ConsoleColor.Green : ConsoleColor.Red;
            _console.Write(animal.Symbol);
        }

    }
}
