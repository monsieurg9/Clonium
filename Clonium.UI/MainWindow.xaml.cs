using Clonium.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clonium.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Field field;
        List<UIСhip> сhips = new List<UIСhip>();
        List<UIPlayer> players = new List<UIPlayer>();
        int timeForTurn;

        public MainWindow()
        {
            InitializeComponent();
            MiddlewareLayer.GetMiddleware().FieldRecalculated += RePaintField;
            MiddlewareLayer.GetMiddleware().GameOver += MainWindow_GameOver;
            MiddlewareLayer.GetMiddleware().ActivePlayerChanged += MainWindow_ActivePlayerChanged;
            MiddlewareLayer.GetMiddleware().TimeChanged += MainWindow_TimeChanged;
        }

        private void MainWindow_TimeChanged(int time)
        {
            TransformTimeTurn(time);
        }

        private void MainWindow_ActivePlayerChanged(int activePlayer)
        {
            players.ForEach(x => x.Active.Fill = null);
            players[activePlayer].Active.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            MiddlewareLayer.GetMiddleware().ResetTimer(timeForTurn);
            TransformTimeTurn(timeForTurn);
        }

        private void MainWindow_GameOver()
        {
            TimeLabel.Content = "congratulations!!!".ToUpper();
            MessageBox.Show(string.Format("Player 'Player{0}' wins!)", MiddlewareLayer.GetMiddleware().GetPlayers().IndexOf(MiddlewareLayer.GetMiddleware().GetPlayers().First(x=>x.Turn)) + 1), "Game Over", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void mnNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGameWindow newGameWindow = new NewGameWindow(this);
            newGameWindow.Show();
        }

        private void TransformTimeTurn(int time)
        {
            if (time % 60 < 10)
                TimeLabel.Content = string.Format("0{0}:0{1}", time / 60, time % 60);
            else if (time % 60 >= 10)
                TimeLabel.Content = string.Format("0{0}:{1}", time / 60, time % 60);
        }

        public void StartGame(int playersCount, int time)
        {
            timeForTurn = time;
            TransformTimeTurn(time);
            MiddlewareLayer.GetMiddleware().SetPlayers(playersCount);
            SetPlayerColors();
            MiddlewareLayer.GetMiddleware().SetTimeTurn(time);
            InitializeField();
            for (int i = 0; i < MiddlewareLayer.GetMiddleware().GetPlayers().Count; i++)
            {
                InitializePlayer(MiddlewareLayer.GetMiddleware().GetPlayers()[i]);
                switch (i)
                {
                    case 0:
                        {
                            InitializeChip(1, 1, 0, MiddlewareLayer.GetMiddleware().GetPlayers()[i].Color);
                            MiddlewareLayer.GetMiddleware().GetChips().Add(new Chip(1, 1, 0, MiddlewareLayer.GetMiddleware().GetPlayers()[i].Color));
                            break;
                        }
                    case 1:
                        {
                            InitializeChip(6, 6, 0, MiddlewareLayer.GetMiddleware().GetPlayers()[i].Color);
                            MiddlewareLayer.GetMiddleware().GetChips().Add(new Chip(6, 6, 0, MiddlewareLayer.GetMiddleware().GetPlayers()[i].Color));
                            break;
                        }
                    case 2:
                        {
                            InitializeChip(6, 1, 0, MiddlewareLayer.GetMiddleware().GetPlayers()[i].Color);
                            MiddlewareLayer.GetMiddleware().GetChips().Add(new Chip(6, 1, 0, MiddlewareLayer.GetMiddleware().GetPlayers()[i].Color));
                            break;
                        }
                    case 3:
                        {
                            InitializeChip(1, 6, 0, MiddlewareLayer.GetMiddleware().GetPlayers()[i].Color);
                            MiddlewareLayer.GetMiddleware().GetChips().Add(new Chip(1, 6, 0, MiddlewareLayer.GetMiddleware().GetPlayers()[i].Color));
                            break;
                        }
                }
            }
            MiddlewareLayer.GetMiddleware().CreateGame();
            MiddlewareLayer.GetMiddleware().StartGame();
        }

        private void SetPlayerColors()
        {
            for (int i = 0; i < MiddlewareLayer.GetMiddleware().GetPlayers().Count; i++)
            {
                if (i == 0)
                    MiddlewareLayer.GetMiddleware().GetPlayers()[i].Color = Properties.Settings.Default.Player1;
                if (i == 1)
                    MiddlewareLayer.GetMiddleware().GetPlayers()[i].Color = Properties.Settings.Default.Player2;
                if (i == 2)
                    MiddlewareLayer.GetMiddleware().GetPlayers()[i].Color = Properties.Settings.Default.Player3;
                if (i == 3)
                    MiddlewareLayer.GetMiddleware().GetPlayers()[i].Color = Properties.Settings.Default.Player4;
            }
        }
        private void RePaintField()
        {
            field.Field1.Children.Clear();
            сhips.Clear();
            MiddlewareLayer.GetMiddleware().GetChips().ForEach(x =>
            {
                InitializeChip(x.X, x.Y, x.DotNumber, x.Color);
            });
        }

        private void mnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Subscribe()
        {

        }

        private void Unsubscribe()
        {

        }

        #region Event methods


        private void InitializeField()
        {
            field = new Field(8);
            ResizeField();
            Major.Children.Add(field);
            Major.Children[Major.Children.Count - 1].SetValue(Grid.RowProperty, 2);
            Major.Children[Major.Children.Count - 1].SetValue(Grid.ColumnProperty, 1);
            
        }

        private void ResizeField()
        {
            if (field != null)
            {
                if (Major.ActualWidth < Major.ActualHeight)
                {
                    field.Height = Major.ActualWidth / 2;
                    field.Width = Major.ActualWidth / 2;
                }
                else if (Major.ActualHeight < Major.ActualWidth)
                {
                    field.Height = Major.ActualHeight / 2 - 80;
                    field.Width = Major.ActualHeight / 2 - 80;
                }
            }
        }

        private void ResizePlayerIcons(UIPlayer player)
        {
            if (Major.ActualWidth < Major.ActualHeight)
            {
                player.Height = Major.ActualWidth / 2;
                player.Width = Major.ActualWidth / 2;
            }
            else if (Major.ActualHeight < Major.ActualWidth)
            {
                player.Height = Major.ActualHeight / 2 - 80;
                player.Width = Major.ActualHeight / 2 - 80;
            }
        }


        private void InitializeChip(int x, int y, int dotNumber, Color color)
        {
            сhips.Add(new UIСhip(color, dotNumber));
            field.Field1.Children.Add(сhips.Last());
            сhips.Last().FilledChip += MainWindow_FilledChip;
            сhips.Last().SetPoints += MainWindow_SetPoints;
            field.Field1.Children[field.Field1.Children.Count - 1].SetValue(Grid.ColumnProperty, x);
            field.Field1.Children[field.Field1.Children.Count - 1].SetValue(Grid.RowProperty, y);
        }

        private void MainWindow_FilledChip(int xc, int yc)
        {
            Chip foundedChip = MiddlewareLayer.GetMiddleware().GetChips().SingleOrDefault(x => x.X == xc && x.Y == yc);
            foundedChip.DotNumber++;
            if (foundedChip != null)
                MiddlewareLayer.GetMiddleware().ClickOnChip(foundedChip.X, foundedChip.Y);
        }

        private void MainWindow_SetPoints(int pointsCount, int xc, int yc)
        {
            MiddlewareLayer.GetMiddleware().GetChips().Single(x => x.X == xc && x.Y == yc).DotNumber = pointsCount;
        }

        #endregion


        private void InitializePlayer(Core.Player player)
        {
            if (players.Count < 4)
            {
                UIPlayer playerControl = new UIPlayer(player.Color, player.Turn);
                ResizePlayerIcons(playerControl);
                players.Add(playerControl);
                if (players.Count == 1)
                {
                    Major.Children.Add(playerControl);
                    Major.Children[Major.Children.Count - 1].SetValue(Grid.ColumnProperty, 0);
                    Major.Children[Major.Children.Count - 1].SetValue(Grid.RowProperty, 1);
                }
                else if (players.Count == 2)
                {
                    Major.Children.Add(playerControl);
                    Major.Children[Major.Children.Count - 1].SetValue(Grid.ColumnProperty, 2);
                    Major.Children[Major.Children.Count - 1].SetValue(Grid.RowProperty, 3);
                }
                else if (players.Count == 3)
                {
                    Major.Children.Add(playerControl);
                    Major.Children[Major.Children.Count - 1].SetValue(Grid.ColumnProperty, 2);
                    Major.Children[Major.Children.Count - 1].SetValue(Grid.RowProperty, 1);
                }
                else if (players.Count == 4)
                {
                    Major.Children.Add(playerControl);
                    Major.Children[Major.Children.Count - 1].SetValue(Grid.ColumnProperty, 0);
                    Major.Children[Major.Children.Count - 1].SetValue(Grid.RowProperty, 3);
                }
            }
        }

        private void mnSaveGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnLoadGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ResizeField();
            players.ForEach(x =>
            {
                ResizePlayerIcons(x);
            });
        }

        private void mnSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settings = new SettingsWindow();
            settings.Show();
        }
    }
}
