using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Clonium.Core
{
    public class Field
    {
        public int Size { get; set; }

        public void OpenChip(List<Chip> chips, Color color)
        {
            while (true)
            {
                Chip foundedChip = chips.SingleOrDefault(x => x.IsFull);
                if (foundedChip == null)
                    break;
                else
                {
                    Chip buffer = chips.SingleOrDefault(x => x.X == foundedChip.X - 1 && x.Y == foundedChip.Y);
                    if (buffer != null)
                        chips.SingleOrDefault(x => x.X == foundedChip.X - 1 && x.Y == foundedChip.Y).DotNumber++;
                    else
                    {
                        if (foundedChip.X - 1 >= 0)
                            chips.Add(new Chip(foundedChip.X - 1, foundedChip.Y, 0, color));
                    }

                    buffer = chips.SingleOrDefault(x => x.X == foundedChip.X + 1 && x.Y == foundedChip.Y);
                    if (buffer != null)
                        chips.SingleOrDefault(x => x.X == foundedChip.X + 1 && x.Y == foundedChip.Y).DotNumber++;
                    else
                    {
                        if (foundedChip.X + 1 < Size)
                            chips.Add(new Chip(foundedChip.X + 1, foundedChip.Y, 0, color));
                    }

                    buffer = chips.SingleOrDefault(x => x.X == foundedChip.X && x.Y == foundedChip.Y - 1);
                    if (buffer != null)
                        chips.SingleOrDefault(x => x.X == foundedChip.X && x.Y == foundedChip.Y - 1).DotNumber++;
                    else
                    {
                        if (foundedChip.Y - 1 >= 0)
                            chips.Add(new Chip(foundedChip.X, foundedChip.Y + 1, 0, color));
                    }

                    buffer = chips.SingleOrDefault(x => x.X == foundedChip.X && x.Y == foundedChip.Y + 1);
                    if (buffer != null)
                        chips.SingleOrDefault(x => x.X == foundedChip.X && x.Y == foundedChip.Y + 1).DotNumber++;
                    else
                    {
                        if (foundedChip.Y + 1 < Size)
                            chips.Add(new Chip(foundedChip.X, foundedChip.Y + 1, 0, color));
                    }
                }
            }
        }




        //public void OpenChip(Chip chip, Color color)
        //{
        //    Task task = new Task(() =>
        //    {
        //        int xc = chip.X;
        //        int yc = chip.Y;

        //        chips.Remove(chip);

        //        Chip foundChip = FindChip(xc - 1, yc);
        //        if (foundChip == null && chip.X > 0)
        //            chips.Add(new Chip(xc - 1, yc, 0, color));
        //        if (foundChip != null && chip.X > 0 && !foundChip.IsFull)
        //        {
        //            foundChip.Color = color;
        //            foundChip.IncDotNumber();
        //        }
        //        if (foundChip != null && chip.X > 0 && foundChip.IsFull)
        //        {
        //            OpenChip(foundChip, color);
        //        }

        //        foundChip = FindChip(xc + 1, yc);
        //        if (foundChip == null && chip.X < size)
        //            chips.Add(new Chip(xc + 1, yc, 0, color));
        //        if (foundChip != null && chip.X < size && !foundChip.IsFull)
        //        {
        //            foundChip.Color = color;
        //            foundChip.IncDotNumber();
        //        }
        //        if (foundChip != null && chip.X < size && foundChip.IsFull)
        //        {
        //            OpenChip(foundChip, color);
        //        }

        //        foundChip = FindChip(xc, yc - 1);
        //        if (foundChip == null && chip.Y > 0)
        //            chips.Add(new Chip(xc, yc - 1, 0, color));
        //        if (foundChip != null && chip.Y > 0 && !foundChip.IsFull)
        //        {
        //            foundChip.Color = color;
        //            foundChip.IncDotNumber();
        //        }
        //        if (foundChip != null && chip.Y > 0 && foundChip.IsFull)
        //        {
        //            OpenChip(foundChip, color);
        //        }

        //        foundChip = FindChip(xc, yc + 1);
        //        if (foundChip == null && chip.Y < size)
        //            chips.Add(new Chip(xc, yc + 1, 0, color));
        //        if (foundChip != null && chip.Y < size && !foundChip.IsFull)
        //        {
        //            foundChip.Color = color;
        //            foundChip.IncDotNumber();
        //        }
        //        if (foundChip != null && chip.Y < size && foundChip.IsFull)
        //        {
        //            OpenChip(foundChip, color);
        //        }
        //    });
        //}

        //private Chip FindChip(int xc, int yc)
        //{
        //    return chips.SingleOrDefault(x => x.X == xc && x.Y == yc);
        //}

        //private Chip FindChip(Color color)
        //{
        //    return chips.SingleOrDefault(x => x.Color == color);
        //}

        //public bool IsGameOver()
        //{
        //    //string color = chips[0].Color;
        //    //Chip founded = null;
        //    //try
        //    //{
        //    //    founded = chips.SingleOrDefault(x => x.Color != color);
        //    //}
        //    //catch(Exception ex)
        //    //{
        //    //    return false;
        //    //}
        //    //return !(founded is null);
        //}

    }
}
