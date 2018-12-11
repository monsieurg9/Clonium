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
                Chip foundedChip = chips.FirstOrDefault(x => x.ReadyToOpen);
                if (foundedChip == null)
                    break;
                else
                {
                    Chip buffer = chips.SingleOrDefault(x => x.X == foundedChip.X - 1 && x.Y == foundedChip.Y);
                    if (buffer != null)
                    {
                        chips.SingleOrDefault(x => x.X == foundedChip.X - 1 && x.Y == foundedChip.Y).DotNumber++;
                        chips.SingleOrDefault(x => x.X == foundedChip.X - 1 && x.Y == foundedChip.Y).Color = color;
                    }
                    else
                    {
                        if (foundedChip.X - 1 >= 0)
                            chips.Add(new Chip(foundedChip.X - 1, foundedChip.Y, 0, color) { IsFull = false, ReadyToOpen = false });
                    }

                    buffer = chips.SingleOrDefault(x => x.X == foundedChip.X + 1 && x.Y == foundedChip.Y);
                    if (buffer != null)
                    {
                        chips.SingleOrDefault(x => x.X == foundedChip.X + 1 && x.Y == foundedChip.Y).DotNumber++;
                        chips.SingleOrDefault(x => x.X == foundedChip.X + 1 && x.Y == foundedChip.Y).Color = color;
                    }
                    else
                    {
                        if (foundedChip.X + 1 < Size)
                            chips.Add(new Chip(foundedChip.X + 1, foundedChip.Y, 0, color) { IsFull = false, ReadyToOpen = false });
                    }

                    buffer = chips.SingleOrDefault(x => x.X == foundedChip.X && x.Y == foundedChip.Y - 1);
                    if (buffer != null)
                    {
                        chips.SingleOrDefault(x => x.X == foundedChip.X && x.Y == foundedChip.Y - 1).DotNumber++;
                        chips.SingleOrDefault(x => x.X == foundedChip.X && x.Y == foundedChip.Y - 1).Color = color;
                    }
                    else
                    {
                        if (foundedChip.Y - 1 >= 0)
                            chips.Add(new Chip(foundedChip.X, foundedChip.Y - 1, 0, color) { IsFull = false, ReadyToOpen = false });
                    }

                    buffer = chips.SingleOrDefault(x => x.X == foundedChip.X && x.Y == foundedChip.Y + 1);
                    if (buffer != null)
                    {
                        chips.SingleOrDefault(x => x.X == foundedChip.X && x.Y == foundedChip.Y + 1).DotNumber++;
                        chips.SingleOrDefault(x => x.X == foundedChip.X && x.Y == foundedChip.Y + 1).Color = color;
                    }
                    else
                    {
                        if (foundedChip.Y + 1 < Size)
                            chips.Add(new Chip(foundedChip.X, foundedChip.Y + 1, 0, color) { IsFull = false, ReadyToOpen = false });
                    }
                }
                chips.Remove(foundedChip);
            }
        }
    }
}
