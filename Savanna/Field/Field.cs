using System;
using System.Collections.Generic;
using System.Text;

namespace Savanna
{
    public class Field
    {
        public Field(int width = 25, int height = 25)
        {
            Width = width;
            Height = height;
            Animals = new ();
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public List<Animal> Animals { get; set; }
        public bool HasFreeSpace { get => Animals.Count < Height * Width; }

        public List<Animal> Carnivores { get => Animals.FindAll(a=>!a.IsHerbivore);}
        public List<Animal> Herbivores { get => Animals.FindAll(a=>a.IsHerbivore);}
    }
}
