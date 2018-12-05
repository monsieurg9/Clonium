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
        int dotNumber;
        int x;
        int y;
        Color color;

        public Chip(int xc, int yc, int dotNumberc, Color colorc)
        {
            dotNumber = dotNumberc;
            x = xc;
            y = yc;
            color = colorc;
        }

        public void IncDotNumber()
        {
            dotNumber += 1;
        }

        public int DotNumber
        {
            get { return dotNumber; }
            set { dotNumber = value; }
        }

        public int X
        {
            get { return x; } 
            set { x = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        Color ChangeColor(Color newColor)
        {
            color = newColor;
            return color;
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}
