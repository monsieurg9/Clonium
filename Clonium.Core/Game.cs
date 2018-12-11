using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clonium.Core
{
    public delegate void PlayerAddedHandler();
    public class Game
    {
        List<Player> players = new List<Player>();

        public List<Player> Players { get => players; set => players = value; }
        public int TimeToTurn { get; set; }
        public bool IsStarted { get; set; }
        public bool IsSuspended { get; set; }
        public bool IsFinished { get; set; }



        public event PlayerAddedHandler PlayersAdded;
        public event ChangeActivePlayerHandler ActivePlayerChanged;
        int playerCount;
        public Game()
        {
        }
        public void AddPlayer()
        {
            players.Add(new Player() { Color = System.Windows.Media.Color.FromRgb(255, 0, 0) });
            playerCount++;
            PlayersAdded.Invoke();
        }

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
            ActivePlayerChanged.Invoke(indexActivePlayer);
        }
    }
}
