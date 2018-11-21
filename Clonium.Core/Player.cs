using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clonium.Core
{
    public class Player
    {
        int dotNumber;
        int chipNumber;
        bool turn;
        string name;
        string color;

        public int DotNumber
        {
            get { return dotNumber; }
            set { dotNumber = value; }
        }

        public int ChipNumber
        {
            get { return chipNumber; }
            set { chipNumber = value; }
        }

        public bool Turn
        {
            get { return turn; }
            set { turn = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public void ChangeColor(string NewColor)
        {
            color = NewColor;
        }

        public int CalcChipsNumber(Field field)
        {
            return field.Chips.Count(x => x.Color == color);
        }

        public int CalcDotNumber(Field field)
        {
            int result = 0;
            field.Chips.ForEach(x =>
            {
                if (x.Color == color)
                    result += x.DotNumber;
            });
            return result;
        }
    }
}
