using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class HerbivoreManager : IHerbivoreManager
    {
        private IRandom _random;
        private IPositionValidator _validator;
        private ICalculations _calculations;

        public HerbivoreManager(IRandom random, IPositionValidator validator, ICalculations calculations)
        {
            _random = random;
            _validator = validator;
            _calculations = calculations;
        }

        public void Move(Field field)
        {
            foreach (var herbivore in field.Herbivores)
            {
                if (herbivore.ClosestEnemy == null)
                {
                    MoveWithoutEnemy(herbivore, field);
                }
                else
                {
                    MoveWithEnemy(herbivore, field);
                }

                //Decrease health;
            }
        }

        private void MoveWithEnemy(Herbivore herbivore, Field field)
        {
            var maxDistance = double.MinValue;
            var bestStep = new Position(0, 0);
            var nextStep = new Position();

            for (nextStep.X = -herbivore.MaxSpeed; nextStep.X <= herbivore.MaxSpeed; nextStep.X++)
            {
                for (nextStep.Y = -herbivore.MaxSpeed; nextStep.Y <= herbivore.MaxSpeed; nextStep.Y++)
                {
                    var newPosition = herbivore.Position.Clone().Add(nextStep);

                    if (!_validator.PositionIsOutOfField(field, newPosition)
                        && (!_validator.PositionIsTaken(field, newPosition) || herbivore.Position.Equals(newPosition)))
                    {
                        var distance = _calculations.Distance(newPosition, herbivore.ClosestEnemy.Position);
                        if (distance > maxDistance)
                        {
                            maxDistance = distance;
                            bestStep = nextStep.Clone();
                        }
                    }
                }
            }

            herbivore.MakeStep(bestStep);
        }

        private void MoveWithoutEnemy(Herbivore herbivore, Field field)
        {
            Position nextStep;
            bool moveIsValide;
            do
            {
                nextStep = _random.GetRandomStep(herbivore.MaxSpeed);
                var newPosition = nextStep.Clone().Add(herbivore.Position);
                moveIsValide = !_validator.PositionIsOutOfField(field, newPosition) &&
                    (!_validator.PositionIsTaken(field, newPosition) || herbivore.Position.Equals(newPosition));

            } while (!moveIsValide);

            herbivore.MakeStep(nextStep);
        }
    }
}
