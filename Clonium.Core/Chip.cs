using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clonium.Core
{
    public class Chip
    {
        int dotNumber;
        int x;
        int y;
        string color;

        public Chip(int xc, int yc, int dotNumberc, string colorc)
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

        string ChangeColor(string newColor)
        {
            color = newColor;
            return color;
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}
