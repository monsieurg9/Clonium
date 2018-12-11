using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Clonium.Core
{
    public class Player
    {
        bool turn;
        Color color;

        public bool Turn
        {
            get { return turn; }
            set { turn = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public void ChangeColor(Color NewColor)
        {
            color = NewColor;
        }
    }
}
