using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class AnimalFactory
    {
        public IAnimal Create(AnimalType type)
        {

            IAnimal animal = type switch
            {
                AnimalType.Antelope => new Antelope(),
                AnimalType.Lion => new Lion(),
                _ => null
            };

            //if null - throw exception 
            //TODO check if field has free space  (throw exception)
            //TODO set position 

            return animal;
        }
    }
}
