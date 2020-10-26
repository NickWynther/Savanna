using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    /// <summary>
    /// Harbivore animals behavior manager.
    /// </summary>
    public class HerbivoreManager : IHerbivoreManager
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
        public HerbivoreManager(IRandom random, IPositionValidator validator, ICalculations calculations)
        {
            _random = random;
            _validator = validator;
            _calculations = calculations;
        }

        /// <summary>
        /// Every herbivore on a field make move.
        /// </summary>
        public void Move(Field field)
        {
            foreach (var herbivore in field.Herbivores)
            {
                Position nextStep = herbivore.HasEnemy ?
                    FindBestStepToEscape(herbivore, field) : GetRandomStep(herbivore, field);

                herbivore.MakeStep(nextStep);
            }
        }

        /// <summary>
        /// Find best step for escaping
        /// </summary>
        private Position FindBestStepToEscape(Herbivore herbivore, Field field)
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

            return bestStep;
        }

        /// <summary>
        /// Get step in a random direction
        /// </summary>
        private Position GetRandomStep(Herbivore herbivore, Field field)
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
            return nextStep;
        }
    }
}
