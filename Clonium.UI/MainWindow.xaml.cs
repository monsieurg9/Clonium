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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void mnNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGameWindow newGameWindow = new NewGameWindow(this);
            newGameWindow.Show();
        }

        public void StartGame()
        {
            game = new Game();
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



        #endregion

        private void mnSaveGame_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnLoadGame_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
