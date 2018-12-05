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
using CoreChip = Clonium.Core.Chip;
using UIChip = Clonium.UI.Сhip;
using CorePlayer = Clonium.Core.Player;
using UIPlayer = Clonium.UI.Player;

namespace Clonium.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game;
        List<UIChip> chips = new List<UIChip>();
        List<UIPlayer> players = new List<UIPlayer>();
        Field field;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Game_PlayersAdded()
        {
            InitializePlayer(game.Players1.Last());
        }

        private void mnNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGameWindow newGameWindow = new NewGameWindow(this);
            newGameWindow.Show();
        }

        public void StartGame()
        { 
            game = new Game();
            game.PlayersAdded += Game_PlayersAdded;
            InitializeField();
            for (int i = 0; i < 2; i++)
            {
                game.AddPlayer();
                InitializeChip(game.Players1.Last(), i==0?1:6, i==0?1:6, 0);
            }
            
            
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
            field = new Field();
            for(int i = 0; i < 8; i++)
            {
                field.Field1.ColumnDefinitions.Add(new ColumnDefinition());
                field.Field1.RowDefinitions.Add(new RowDefinition());
            }
            Major.Children.Add(field);
            Major.Children[Major.Children.Count - 1].SetValue(Grid.RowProperty, 2);
            Major.Children[Major.Children.Count - 1].SetValue(Grid.ColumnProperty, 1);
        }
        
        private void SetChipsOnField()
        {
            
        }

        private void InitializeChip(Clonium.Core.Player player, int x, int y, int dotNumber)
        {
            chips.Add(new UIChip(player.Color, dotNumber, this));
            field.Field1.Children.Add(chips.Last());
            field.Field1.Children[field.Field1.Children.Count - 1].SetValue(Grid.ColumnProperty, y);
            field.Field1.Children[field.Field1.Children.Count - 1].SetValue(Grid.RowProperty, x);
            field.Field1.Children[field.Field1.Children.Count - 1].SetValue(BackgroundProperty, new SolidColorBrush(player.Color));
            //field.Field1.Children[field.Field1.Children.Count - 1].SetValue(WidthProperty, field.Field1.ColumnDefinitions[0].ActualWidth);
            //field.Field1.Children[field.Field1.Children.Count - 1].SetValue(HeightProperty, field.Field1.RowDefinitions[0].ActualHeight);
        }

        private void DestroyChip(UIChip chip)
        {
            field.Field1.Children.Remove(chip);
            chips.Remove(chip);
        }

        private void InitializePlayer(CorePlayer player)
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

        #endregion

        private void mnSaveGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnLoadGame_Click(object sender, RoutedEventArgs e)
        {

        }

        public void OpenChip(UIChip chip)
        {
            int chipX = Convert.ToInt32(chip.GetValue(Grid.RowProperty));
            int chipY = Convert.ToInt32(chip.GetValue(Grid.ColumnProperty));
            if (FindChip(chipX - 1, chipY) == null && chipX > 0)
            {
                InitializeChip(game.Players1[0], chipX - 1, chipY, 0);
            }
            if (FindChip(chipX + 1, chipY) == null && chipX < 7)
            {
                InitializeChip(game.Players1[0], chipX + 1, chipY, 0);
            }
            if (FindChip(chipX, chipY - 1) == null && chipY > 0)
            {
                InitializeChip(game.Players1[0], chipX, chipY - 1, 0);
            }
            if (FindChip(chipX, chipY + 1) == null && chipY < 7)
            {
                InitializeChip(game.Players1[0], chipX, chipY + 1, 0);
            }
            DestroyChip(chip);
        }

        private UIChip FindChip(int xc, int yc)
        {
            return chips.SingleOrDefault(x => Convert.ToInt32(x.GetValue(Grid.RowProperty)) == xc && Convert.ToInt32(x.GetValue(Grid.ColumnProperty)) == yc);
        }
    }
}
