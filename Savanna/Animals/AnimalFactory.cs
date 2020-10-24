using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class AnimalFactory : IAnimalFactory
    {
        private IRandom _random;
        private IPositionValidator _validator;

        public AnimalFactory(IRandom random , IPositionValidator validator)
        {
            _random = random;
            _validator = validator;
        }

        public Animal Create(Field field, AnimalType type )
        {
            Animal animal = type switch
            {
                AnimalType.Antelope => new Antelope(),
                AnimalType.Lion => new Lion(),
                _ => throw new InvalidOperationException("Incorect animal type")
            };

            animal.Position = GetFreePosition(field);
            field.Animals.Add(animal);
            return animal;
        }

        private Position GetFreePosition(Field field)
        {
            if (field.HasFreeSpace == false)
            {
                throw new InvalidOperationException("Field has no free space");
            }

            Position newPosition;

            do
            {
                newPosition = new Position(_random.Get(field.Width), _random.Get(field.Height));

            } while (_validator.PositionIsTaken(field, newPosition));

            return newPosition;
        }
    }
}
