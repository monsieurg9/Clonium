using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Media;

namespace Clonium.Core
{

    #region [ Delegators ]
    public delegate void ChangeActivePlayerHandler(int activePlayer);
    public delegate void GameOverHandler();
    public delegate void TimeChangedHandler(int time);
    public delegate void ChipDotsAddedHandler(int dotCount);
    public delegate void FieldReCalculatedHandler();
    #endregion

    public class MiddlewareLayer
    {
        private Game game = new Game();
        private Field field;
        private List<Player> players = new List<Player>();
        private List<Chip> chips = new List<Chip>();
        private Dictionary<int, Color> playerColors = new Dictionary<int, Color>();
        private int timeTurn;
        private Timer timer = new Timer();

        #region [ Public ]
        public int ActivePlayer { get; set; }
        #endregion


        #region [ Events ]
        public event GameOverHandler GameOver;
        public event TimeChangedHandler TimeChanged;
        public event ChipDotsAddedHandler ChipDotsAdded;
        public event FieldReCalculatedHandler FieldRecalculated;
        #endregion


        #region [ Constructors ]
        public MiddlewareLayer()
        {
            for (int i = 0; i < 4; i++)
            {
                playerColors.Add(i + 1, Brushes.Red.Color);
            }
            game.ActivePlayerChanged += SetActivePlayer;
        }

        #endregion


        #region [ Common Methods ]

        public void SetTimeTurn(int time)
        {
            timeTurn = time;
        }

        private void SetTimer()
        {
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (timeTurn == 0)
                ChangeTurn();
            else
            {
                timeTurn--;
                TimeChanged.Invoke(timeTurn);
            }
        }

        #endregion

        #region [ Game Methods ]
        public void CreateGame()
        {
            game = new Game();
            game.TimeToTurn = timeTurn;
            game.Players = players;
            SetField(8);
        }

        public void StartGame()
        {
            game.IsFinished = false;
            game.IsStarted = true;
            game.IsSuspended = false;
        }

        public void ChangeTurn()
        {
            CheckGameOvering();
            game.ChangeTurn();
        }

        private void CheckGameOvering()
        {
            Color zeroColor = chips[0].Color;
            if (chips.Count(x => x.Color == zeroColor) == chips.Count)
            {
                game.IsFinished =  true;
                GameOver.Invoke();
            }
        }

        #endregion

        #region [ Field Methods ]
        private void SetField(int size)
        {
            field = new Field();
            field.Size = size;
        }
        #endregion

        #region [ Player Methods ]

        public void SetPlayers(int playersCount)
        {
            for (int i = 0; i < playersCount; i++)
            {
                players.Add(new Player());
                players.Last().Color = playerColors[i + 1];
            }
            players[0].Turn = true;
        }

        private void SetActivePlayer(int num)
        {
            ActivePlayer = num;
        }

        #endregion

        #region [ Chip Methods ]
        public void ClickOnChip(int row, int col)
        {
            Chip chip = chips.Single(x => x.X == row && x.Y == col);
            if (!chip.IsFull)
            {
                chip.DotNumber++;
                ChipDotsAdded(chip.DotNumber);
            }
            else
            {
                field.OpenChip(chips, players.Single(x=>x.Turn).Color);
                FieldRecalculated.Invoke();
            }
        }

        public List<Chip> GetChips()
        {
            return chips;
        }
        #endregion
    }
}
