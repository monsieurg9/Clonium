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
        Game game;
        Field field;
        List<UIСhip> сhips = new List<UIСhip>();
        List<UIPlayer> players = new List<UIPlayer>();

        MiddlewareLayer middlewareLayer = new MiddlewareLayer();

        public MainWindow()
        {
            InitializeComponent();
            middlewareLayer.FieldRecalculated += RePaintField;
        }

        public MiddlewareLayer GetMiddlewareLayer()
        {
            return middlewareLayer;
        }

        private void mnNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGameWindow newGameWindow = new NewGameWindow(this);
            newGameWindow.Show();
        }

        public void StartGame(int playersCount)
        {
            middlewareLayer.SetPlayers(playersCount);
            middlewareLayer.SetTimeTurn(60);
            InitializeField();
            middlewareLayer.CreateGame();
            middlewareLayer.StartGame();

            //game = new Game();
            //game.PlayersAdded += Game_PlayersAdded;
            //InitializeField();
            //for (int i = 0; i < 2; i++)
            //{
            //    game.AddPlayer();
            //    InitializeChip(game.Players.Last(), i == 0 ? 1 : 6, i == 0 ? 1 : 6, 0);
            //}
        }

        private void RePaintField()
        {
            сhips.ForEach(x =>
            {
                field.Field1.Children.Clear();
                сhips.Clear();
            });
            middlewareLayer.GetChips().ForEach(x =>
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


        private void InitializeChip(int x, int y, int dotNumber, Color color)
        {
            сhips.Add(new UIСhip(color, dotNumber));
            field.Field1.Children.Add(сhips.Last());
            сhips.Last().FilledChip += MainWindow_FilledChip;
            field.Field1.Children[field.Field1.Children.Count - 1].SetValue(Grid.ColumnProperty, x);
            field.Field1.Children[field.Field1.Children.Count - 1].SetValue(Grid.RowProperty, y);
        }


        //private void InitializeChip(Clonium.Core.Player player, int x, int y, int dotNumber)
        //{
        //    сhips.Add(new UIСhip(player.Color, dotNumber));
        //    field.Field1.Children.Add(сhips.Last());
        //    //сhips.Last().FilledChip += MainWindow_FilledChip;
        //    field.Field1.Children[field.Field1.Children.Count - 1].SetValue(Grid.ColumnProperty, x);
        //    field.Field1.Children[field.Field1.Children.Count - 1].SetValue(Grid.RowProperty, y);
        //}

        private void MainWindow_FilledChip(FilledEventArgs eventArgs)
        {
            middlewareLayer.
        }

        //private void DestroyChip(UIСhip chip)
        //{
        //    field.Field1.Children.Remove(chip);
        //    сhips.Remove(chip);

        //}

        //public void OpenChip(UIСhip chip)
        //{
        //    int chipX = Grid.GetColumn(chip);
        //    int chipY = Grid.GetRow(chip);
        //    UIСhip checkingChip = FindChip(chipX - 1, chipY);
        //    if (checkingChip == null && chipX > 0)
        //    {
        //        InitializeChip(game.Players[0], chipX - 1, chipY, 0);
        //    }
        //    else if (checkingChip != null && chipX > 0)
        //    {
        //        checkingChip.AddPoint();
        //    }

        //    checkingChip = FindChip(chipX + 1, chipY);
        //    if (checkingChip == null && chipX < 7)
        //    {
        //        InitializeChip(game.Players[0], chipX + 1, chipY, 0);
        //    }
        //    else if (checkingChip != null && chipX < 7)
        //    {
        //        checkingChip.AddPoint();
        //    }

        //    checkingChip = FindChip(chipX, chipY - 1);
        //    if (checkingChip == null && chipY > 0)
        //    {
        //        InitializeChip(game.Players[0], chipX, chipY - 1, 0);
        //    }
        //    else if (checkingChip != null && chipY > 0)
        //    {
        //        checkingChip.AddPoint();
        //    }

        //    checkingChip = FindChip(chipX, chipY + 1);
        //    if (checkingChip == null && chipY < 7)
        //    {
        //        InitializeChip(game.Players[0], chipX, chipY + 1, 0);
        //    }
        //    else if (checkingChip != null && chipY < 7)
        //    {
        //        checkingChip.AddPoint();
        //    }
        //    DestroyChip(chip);
        //}
        //private UIСhip FindChip(int xc, int yc)
        //{
        //    return сhips.SingleOrDefault(x => Grid.GetColumn(x) == xc && Grid.GetRow(x) == yc);
        //}

        #endregion


        //private void Game_PlayersAdded()
        //{
        //    InitializePlayer(game.Players.Last());
        //}


        private void InitializePlayer(Core.Player player)
        {
            if (players.Count < 4)
            {
                players.Add(new UIPlayer(player.Color, player.Turn));
                if (players.Count == 1)
                {
                    Major.Children.Add(players.Last());
                    Major.Children[Major.Children.Count - 1].SetValue(Grid.ColumnProperty, 0);
                    Major.Children[Major.Children.Count - 1].SetValue(Grid.RowProperty, 1);
                    Major.Children[Major.Children.Count - 1].SetValue(WidthProperty, Major.ColumnDefinitions[0].ActualWidth);
                    Major.Children[Major.Children.Count - 1].SetValue(HeightProperty, Major.RowDefinitions[1].ActualHeight);
                }
                else if (players.Count == 2)
                {
                    Major.Children.Add(players.Last());
                    Major.Children[Major.Children.Count - 1].SetValue(Grid.ColumnProperty, 2);
                    Major.Children[Major.Children.Count - 1].SetValue(Grid.RowProperty, 3);
                    Major.Children[Major.Children.Count - 1].SetValue(WidthProperty, Major.ColumnDefinitions[2].ActualWidth);
                    Major.Children[Major.Children.Count - 1].SetValue(HeightProperty, Major.RowDefinitions[3].ActualHeight);
                }
                else if (players.Count == 3)
                {
                    Major.Children.Add(players.Last());
                    Major.Children[Major.Children.Count - 1].SetValue(Grid.ColumnProperty, 2);
                    Major.Children[Major.Children.Count - 1].SetValue(Grid.RowProperty, 1);
                    Major.Children[Major.Children.Count - 1].SetValue(WidthProperty, Major.ColumnDefinitions[2].ActualWidth);
                    Major.Children[Major.Children.Count - 1].SetValue(HeightProperty, Major.RowDefinitions[1].ActualHeight);
                }
                else if (players.Count == 4)
                {
                    Major.Children.Add(players.Last());
                    Major.Children[Major.Children.Count - 1].SetValue(Grid.ColumnProperty, 0);
                    Major.Children[Major.Children.Count - 1].SetValue(Grid.RowProperty, 3);
                    Major.Children[Major.Children.Count - 1].SetValue(WidthProperty, Major.ColumnDefinitions[0].ActualWidth);
                    Major.Children[Major.Children.Count - 1].SetValue(HeightProperty, Major.RowDefinitions[3].ActualHeight);
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
        }

        private void mnSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settings = new SettingsWindow();
            settings.Show();
        }
    }
}
