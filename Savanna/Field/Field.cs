using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Savanna
{
    public class Field
    {
        public Field(int width = 15, int height = 15)
        {
            Width = width;
            Height = height;
            Animals = new ();
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public List<Animal> Animals { get; set; }
        public bool HasFreeSpace { get => Animals.Count < Height * Width; }

        public List<Carnivore> Carnivores { get => Animals.OfType<Carnivore>().ToList(); }
        public List<Herbivore> Herbivores { get => Animals.OfType<Herbivore>().ToList(); }
    }
}
