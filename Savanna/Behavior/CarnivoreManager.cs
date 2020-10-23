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
            int bestStepX = 0, bestStepY = 0;

            for (int stepX=-carnivore.MaxSpeed; stepX <= carnivore.MaxSpeed; stepX++)
            {
                for (int stepY = -carnivore.MaxSpeed; stepY <= carnivore.MaxSpeed; stepY++)
                {
                    var newPosition = new Position(carnivore.Position.X + stepX, carnivore.Position.Y + stepY);

                    if (!_validator.PositionIsOutOfField(field, newPosition) 
                        && (!_validator.PositionIsTakenByCarnivore(field , newPosition) || carnivore.Position.Equals(newPosition)))
                    {    
                        var distance = _calculations.Distance(newPosition, carnivore.ClosestEnemy.Position);
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            bestStepX = stepX;
                            bestStepY = stepY;
                            if (carnivore.ClosestEnemy.Position.Equals(newPosition))
                            {
                                break;
                            }
                        }
                    }
                }
            }
            
            carnivore.MakeStep(bestStepX, bestStepY);
            if (carnivore.Position.Equals(carnivore.ClosestEnemy.Position))
            {
                carnivore.Eat((Herbivore)carnivore.ClosestEnemy);
            }
        }

        private void MoveWithoutEnemy(Animal carnivore , Field field)
        {
            int stepX, stepY;
            bool moveIsValide;
            do
            {
                stepX = _random.Get(-carnivore.MaxSpeed, carnivore.MaxSpeed);
                stepY = _random.Get(-carnivore.MaxSpeed, carnivore.MaxSpeed);
                var newPosition = new Position(carnivore.Position.X + stepX, carnivore.Position.Y + stepY);
                moveIsValide = !_validator.PositionIsOutOfField(field, newPosition) && 
                    (!_validator.PositionIsTaken(field, newPosition) || carnivore.Position.Equals(newPosition));

            } while (!moveIsValide);

            carnivore.MakeStep(stepX, stepY);
        }
    }
}
