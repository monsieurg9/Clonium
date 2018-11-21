using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clonium.Core
{
    public class Game
    {
        List<Player> Players = new List<Player>();

        public List<Player> Players1 { get => Players; set => Players = value; }

        public void ChangeTurn()
        {
            int indexActivePlayer = Players.IndexOf(Players.Single(x => x.Turn));
            if (indexActivePlayer == Players.Count - 1)
            {
                Players[indexActivePlayer].Turn = false;
                Players[0].Turn = true;
            }
            else
            {
                Players[indexActivePlayer].Turn = false;
                Players[indexActivePlayer+1].Turn = true;
            }
        }
    }
}
