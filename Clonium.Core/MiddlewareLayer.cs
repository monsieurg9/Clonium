using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Media;
using System.Windows.Threading;

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
        #region [ Singleton ]
        private static MiddlewareLayer _instance;

        public static MiddlewareLayer GetMiddleware()
        {
            if (_instance == null)
                _instance = new MiddlewareLayer();
            return _instance;
        }
        #endregion


        private Game game = new Game();
        private Field field;
        private List<Player> players = new List<Player>();
        private List<Chip> chips = new List<Chip>();
        private Dictionary<int, Color> playerColors = new Dictionary<int, Color>();
        private int timeTurn;
        private DispatcherTimer dTimer = new DispatcherTimer();

        #region [ Public ]
        public int ActivePlayer { get; set; }
        #endregion


        #region [ Events ]
        public event GameOverHandler GameOver;
        public event TimeChangedHandler TimeChanged;
        public event FieldReCalculatedHandler FieldRecalculated;
        public event ChangeActivePlayerHandler ActivePlayerChanged;
        #endregion


        #region [ Constructors ]
        public MiddlewareLayer()
        {
            game.ActivePlayerChanged += SetActivePlayer;
        }

        #endregion


        #region [ Common Methods ]

        public void SetTimeTurn(int time)
        {
            timeTurn = time;
            dTimer.Tick += DTimer_Tick;
            SetTimerInterval();
        }

        private void DTimer_Tick(object sender, EventArgs e)
        {
            if (timeTurn == 0)
            {
                ChangeTurn();
                ActivePlayerChanged.Invoke(players.IndexOf(players.First(x => x.Turn)));
                SetTimerInterval();
            }
            else
            {
                timeTurn--;
                TimeChanged.Invoke(timeTurn);
                SetTimerInterval();
            }
        }

        private void SetTimerInterval()
        {
            dTimer.Interval = new TimeSpan(0, 0, 1);
        }

        public void ResetTimer(int time)
        {
            timeTurn = time;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (timeTurn == 0)
            {
                ChangeTurn();
                ActivePlayerChanged.Invoke(players.IndexOf(players.First(x=>x.Turn)));
                SetTimerInterval();
            }
            else
            {
                timeTurn--;
                TimeChanged.Invoke(timeTurn);
                SetTimerInterval();
            }
        }

        #endregion

        #region [ Game Methods ]
        public void CreateGame()
        {
            game = new Game();
            game.ActivePlayerChanged += SetActivePlayer;
            game.TimeToTurn = timeTurn;
            game.Players = players;
            SetField(8);
        }

        public void StartGame()
        {
            game.IsFinished = false;
            game.IsStarted = true;
            game.IsSuspended = false;
            dTimer.Start();
        }

        public void ChangeTurn()
        {
            CheckGameOvering();
            game.ChangeTurn();
            ActivePlayerChanged.Invoke(players.IndexOf(players.First(x => x.Turn)));
        }

        private void CheckGameOvering()
        {
            Color zeroColor = chips[0].Color;
            if (chips.Count(x => x.Color == zeroColor) == chips.Count)
            {
                game.IsFinished = true;
                dTimer.Stop();
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
            }
            players[0].Turn = true;
        }

        private void SetActivePlayer(int num)
        {
            ActivePlayer = num;
        }

        public List<Player> GetPlayers()
        {
            return players;
        }

        public bool FindPlayerByColor(Color color)
        {
            return players.First(x => x.Color == color).Turn;
        }

        #endregion

        #region [ Chip Methods ]
        public void ClickOnChip(int row, int col)
        {
            field.OpenChip(chips, players.Single(x => x.Turn).Color);
            FieldRecalculated.Invoke();
        }

        public List<Chip> GetChips()
        {
            return chips;
        }
        #endregion
    }
}
