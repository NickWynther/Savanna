using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class CarnivoreManager : ICarnivoreManager
    {
        public void Move(Field field)
        {
            foreach (var carnivore in field.Carnivores)
            {
                if (carnivore.ClosestEnemy == null)
                {
                    //MoveWithoutEnemy(carnivore, field);
                }
                else
                {
                    //MoveWithEnemy(carnivore, field);
                }

                //AnimalManager.DecreaseHealth(carnivore);
            }
        } 
    }
}
