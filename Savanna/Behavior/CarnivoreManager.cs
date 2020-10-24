using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class CarnivoreManager : ICarnivoreManager
    {
        private IRandom _random;
        private IPositionValidator _validator;
        private ICalculations _calculations;

        public CarnivoreManager(IRandom random , IPositionValidator validator , ICalculations calculations)
        {
            _random = random;
            _validator = validator;
            _calculations = calculations;
        }

        public void Move(Field field)
        {
            foreach (var carnivore in field.Carnivores)
            {
                if (carnivore.ClosestEnemy == null)
                {
                    MoveWithoutEnemy(carnivore, field);
                }
                else
                {
                    MoveWithEnemy((Carnivore)carnivore, field);
                }

                //Decrease health;
            }
        }

        private void MoveWithEnemy(Carnivore carnivore, Field field)
        {
            var minDistance = double.MaxValue;
            var bestStep = new Position(0,0);
            var nextStep = new Position();

            for (nextStep.X =-carnivore.MaxSpeed; nextStep.X <= carnivore.MaxSpeed; nextStep.X++)
            {
                for (nextStep.Y = -carnivore.MaxSpeed; nextStep.Y <= carnivore.MaxSpeed; nextStep.Y++)
                {
                    var newPosition = carnivore.Position.Clone().Add(nextStep);

                    if (!_validator.PositionIsOutOfField(field, newPosition) 
                        && (!_validator.PositionIsTakenByCarnivore(field , newPosition) || carnivore.Position.Equals(newPosition)))
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
            
            carnivore.MakeStep(bestStep);
            if (carnivore.Position.Equals(carnivore.ClosestEnemy.Position))
            {
                carnivore.Eat((Herbivore)carnivore.ClosestEnemy);
            }
        }

        private void MoveWithoutEnemy(Animal carnivore , Field field)
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

            carnivore.MakeStep(nextStep);
        }
    }
}
