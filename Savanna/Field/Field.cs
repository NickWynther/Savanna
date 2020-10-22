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
        public List<IAnimal> Animals { get; set; }
        public bool HasFreeSpace { get => Animals.Count < Height * Width; }

        public List<IAnimal> CarnivoreList { get => Animals.FindAll(a=>!a.IsHerbivore);}
        public List<IAnimal> HerbivoreList { get => Animals.FindAll(a=>a.IsHerbivore);}
    }
}
