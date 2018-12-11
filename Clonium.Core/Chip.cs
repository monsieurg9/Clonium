using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Clonium.Core
{
    public class Chip
    {
        public Chip(int xc, int yc, int dotNumberc, Color colorc)
        {
            DotNumber = dotNumberc;
            X = xc;
            Y = yc;
            Color = colorc;
        }

        public int DotNumber { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsFull
        {
            get { return DotNumber >= 3; }
            set { }
        }

        public bool ReadyToOpen
        {
            get { return DotNumber >= 4; }
            set { }
        }

        Color ChangeColor(Color newColor)
        {
            Color = newColor;
            return Color;
        }

        public Color Color { get; set; }
    }
}
