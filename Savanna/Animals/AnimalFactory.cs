using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class AnimalFactory : IAnimalFactory
    {
        private IRandom _random;
        private IValidator _validator;

        public AnimalFactory(IRandom random , IValidator validator)
        {
            _random = random;
            _validator = validator;
        }

        public IAnimal Create(Field field, AnimalType type )
        {
            IAnimal animal = type switch
            {
                AnimalType.Antelope => new Antelope(),
                AnimalType.Lion => new Lion(),
                _ => throw new InvalidOperationException("Incorect animal type")
            };

            animal.Position = GetFreePosition(field);
            return animal;
        }

        private Position GetFreePosition(Field field)
        {
            if (field.HasFreeSpace == false)
            {
                throw new InvalidOperationException("Field has no free space");
            }

            Position newPosition = null;

            do
            {
                newPosition = new Position(_random.Get(field.Width), _random.Get(field.Height));

            } while (_validator.PositionIsTaken(field, newPosition));

            return newPosition;
        }
    }
}
