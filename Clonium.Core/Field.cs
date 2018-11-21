using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clonium.Core
{
    public class Field
    {
        int size;
        List<Chip> chips = new List<Chip>();
        string color;

        public List<Chip> Chips { get => chips; set => chips = value; }

        public string ChangeColor(string newColor)
        {
            color = newColor;
            return color;
        }

        public void OpenChip(Chip chip)
        {
            if (chip.DotNumber < 3 && chip.DotNumber > 1)
            {
                chip.IncDotNumber();
            }
            else
            {
                bool onBorder = false;
                bool inCorner = false;

                if (chip.X == 0 && chip.Y == 0)
                {
                    chips.Add(new Chip(0, 1, 1, chip.Color));
                    chips.Add(new Chip(1, 0, 1, chip.Color));
                    inCorner = true;
                }
                if (chip.X == 0 && chip.Y == size-1)
                {
                    chips.Add(new Chip(0, size-2, 1, chip.Color));
                    chips.Add(new Chip(1, size-1, 1, chip.Color));
                    inCorner = true;
                }
                if (chip.X == size - 1 && chip.Y == 0)
                {
                    chips.Add(new Chip(size - 2, 0, 1, chip.Color));
                    chips.Add(new Chip(size - 1, 1, 1, chip.Color));
                    inCorner = true;
                }
                if (chip.X == size - 1 && chip.Y == size - 1)
                {
                    chips.Add(new Chip(size - 2, size - 1, 1, chip.Color));
                    chips.Add(new Chip(size - 1, size - 2, 1, chip.Color));
                    inCorner = true;
                }

                if (chip.X == size - 1 && !inCorner)
                {
                    chips.Add(new Chip(chip.X - 1, size - 1, 1, chip.Color));
                    chips.Add(new Chip(chip.X, size - 2, 1, chip.Color));
                    chips.Add(new Chip(chip.X + 1, size - 1, 1, chip.Color));
                    onBorder = true;
                }
                if (chip.X == 0 && !inCorner)
                {
                    chips.Add(new Chip(chip.X - 1, 0, 1, chip.Color));
                    chips.Add(new Chip(chip.X, 1, 1, chip.Color));
                    chips.Add(new Chip(chip.X + 1, 0, 1, chip.Color));
                    onBorder = true;
                }
                if (chip.Y == size - 1 && !inCorner)
                {
                    chips.Add(new Chip(chip.X, chip.Y - 1, 1, chip.Color));
                    chips.Add(new Chip(chip.X - 1, chip.Y, 1, chip.Color));
                    chips.Add(new Chip(chip.X, chip.Y + 1, 1, chip.Color));
                    onBorder = true;
                }
                if (chip.Y == 0 && !inCorner)
                {
                    chips.Add(new Chip(0, chip.Y - 1, 1, chip.Color));
                    chips.Add(new Chip(1, chip.Y, 1, chip.Color));
                    chips.Add(new Chip(0, chip.Y + 1, 1, chip.Color));
                    onBorder = true;
                }

                if (!onBorder && !inCorner)
                {
                    chips.Add(new Chip(chip.X - 1, chip.Y - 1, 1, chip.Color));
                    chips.Add(new Chip(chip.X + 1, chip.Y + 1, 1, chip.Color));
                    chips.Add(new Chip(chip.X - 1, chip.Y + 1, 1, chip.Color));
                    chips.Add(new Chip(chip.X + 1, chip.Y - 1, 1, chip.Color));
                }
                chips.Remove(chip);
            }
        }

        public bool IsGameOver()
        {
            string color = chips[0].Color;
            Chip founded = null;
            try
            {
                founded = chips.SingleOrDefault(x => x.Color != color);
            }
            catch(Exception ex)
            {
                return false;
            }
            return !(founded is null);
        }

    }
}
