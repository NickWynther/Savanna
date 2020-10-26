using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    /// <summary>
    /// This class is used to create new animals on a field.
    /// </summary>
    public class AnimalFactory : IAnimalFactory
    {
        private IRandom _random;
        private IPositionValidator _validator;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="random">Random generator for initial position creating.</param>
        /// <param name="validator">Position validator</param>
        public AnimalFactory(IRandom random , IPositionValidator validator)
        {
            _random = random;
            _validator = validator;
        }

        /// <summary>
        /// Create new animal and  add it to field.
        /// </summary>
        /// <param name="field">Field where to place new animal.</param>
        /// <param name="type">Animal specie.</param>
        /// <returns>New animal.</returns>
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

        /// <summary>
        /// Get free position on the field. If field is full , throw InvalidOperationException.
        /// </summary>
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
