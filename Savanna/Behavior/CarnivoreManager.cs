using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{

    /// <summary>
    /// Carnivore animals behavior manager.
    /// </summary>
    public class CarnivoreManager : ICarnivoreManager
    {
        private IRandom _random;
        private IPositionValidator _validator;
        private ICalculations _calculations;

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="random">Random generator for new step creation.</param>
        /// <param name="validator"> Psotion validator.</param>
        /// <param name="calculations"> Game math.</param>
        public CarnivoreManager(IRandom random , IPositionValidator validator , ICalculations calculations)
        {
            _random = random;
            _validator = validator;
            _calculations = calculations;
        }

        /// <summary>
        /// Every carnivore on a field make move.
        /// </summary>
        public void Move(Field field)
        {
            foreach (var carnivore in field.Carnivores)
            {
                Position nextStep = carnivore.HasEnemy ? 
                    FindBestStepForCatching(carnivore, field) : GetRandomStep(carnivore, field);
                
                carnivore.MakeStep(nextStep);
                TryToEatVictim(carnivore);
            }
        }

        /// <summary>
        /// If carnivore has a victim on the same position. Carnivores eats. 
        /// </summary>
        private static void TryToEatVictim(Carnivore carnivore)
        {
            if (carnivore.HasEnemy && carnivore.Position.Equals(carnivore.ClosestEnemy.Position))
            {
                carnivore.Eat((Herbivore)carnivore.ClosestEnemy);
            }
        }

        /// <summary>
        /// Find best step for victim catching
        /// </summary>
        private Position FindBestStepForCatching(Carnivore carnivore, Field field)
        {
            var minDistance = double.MaxValue;
            var bestStep = new Position(0, 0);
            var nextStep = new Position();

            for (nextStep.X = -carnivore.MaxSpeed; nextStep.X <= carnivore.MaxSpeed; nextStep.X++)
            {
                for (nextStep.Y = -carnivore.MaxSpeed; nextStep.Y <= carnivore.MaxSpeed; nextStep.Y++)
                {
                    var newPosition = carnivore.Position.Clone().Add(nextStep);

                    if (!_validator.PositionIsOutOfField(field, newPosition)
                        && (!_validator.PositionIsTakenByCarnivore(field, newPosition) || carnivore.Position.Equals(newPosition)))
                    {
                        var distance = _calculations.Distance(newPosition, carnivore.ClosestEnemy.Position);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            bestStep = nextStep.Clone();
                            if (carnivore.ClosestEnemy.Position.Equals(newPosition))
                            {
                                break;
                            }
                        }
                    }
                }
            }

            return bestStep;
        }

        /// <summary>
        /// Get step in a random direction
        /// </summary>
        private Position GetRandomStep(Animal carnivore, Field field)
        {
            Position nextStep;
            bool moveIsValide;
            do
            {
                nextStep = _random.GetRandomStep(carnivore.MaxSpeed);
                var newPosition = nextStep.Clone().Add(carnivore.Position);
                moveIsValide = !_validator.PositionIsOutOfField(field, newPosition) &&
                    (!_validator.PositionIsTaken(field, newPosition) || carnivore.Position.Equals(newPosition));

            } while (!moveIsValide);
            return nextStep;
        }
    }
}
