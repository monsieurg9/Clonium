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
using System.Windows.Shapes;

namespace Clonium.UI
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        List<Color> colors = new List<Color>();
        public SettingsWindow()
        {
            InitializeComponent();
            colors.Add((Color)ColorConverter.ConvertFromString("#FFFC0A0A"));
            colors.Add((Color)ColorConverter.ConvertFromString("#FFFFF81C"));
            colors.Add((Color)ColorConverter.ConvertFromString("#FF5AF706"));
            colors.Add((Color)ColorConverter.ConvertFromString("#FF0B1FFA"));
            colors.Add((Color)ColorConverter.ConvertFromString("#FF9A00A0"));
            colors.Add((Color)ColorConverter.ConvertFromString("#FFFF6E97"));
            colors.Add((Color)ColorConverter.ConvertFromString("#FF11F9E4"));
            colors.Add((Color)ColorConverter.ConvertFromString("#FF44A870"));
            colors.Add((Color)ColorConverter.ConvertFromString("#FF000000"));
            colors.Add((Color)ColorConverter.ConvertFromString("#FFFFFFFF"));
            colors.Add((Color)ColorConverter.ConvertFromString("#FFB9B9B9"));
            colors.Add((Color)ColorConverter.ConvertFromString("#FFEE9E0C"));
            colors.Add((Color)ColorConverter.ConvertFromString("#FFC892A0"));
            colors.Add((Color)ColorConverter.ConvertFromString("#FF803030"));
            colors.Add((Color)ColorConverter.ConvertFromString("#FF04510D"));
            colors.Add((Color)ColorConverter.ConvertFromString("#FFC5C70F"));
        }

        private void GetPlayerColor(string player)
        {
            Color color;
            if (player == "Player1")
            {
                color = Properties.Settings.Default.Player1;
                FindRect(color);
            }
            if (player == "Player2")
            {
                color = Properties.Settings.Default.Player2;
                FindRect(color);
            }
            if (player == "Player3")
            {
                color = Properties.Settings.Default.Player3;
                FindRect(color);
            }
            if (player == "Player4")
            {
                color = Properties.Settings.Default.Player4;
                FindRect(color);
            }
        }

        private void SendPlayerColor(Color color, int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    {
                        Properties.Settings.Default["Player1"] = color;
                        Properties.Settings.Default.Save();
                        break;
                    }
                case 1:
                    {
                        Properties.Settings.Default["Player2"] = color;
                        Properties.Settings.Default.Save();
                        break;
                    }
                case 2:
                    {
                        Properties.Settings.Default["Player3"] = color;
                        Properties.Settings.Default.Save();
                        break;
                    }
                case 3:
                    {
                        Properties.Settings.Default["Player4"] = color;
                        Properties.Settings.Default.Save();
                        break;
                    }
            }
        }

        private void FindRect(Color color)
        {
            int index = colors.IndexOf(color);
            Rectangle rect = (Rectangle)FindName(string.Format("{0}{1}", "rect", index+1));
            ClearBorders();
            rect.Stroke = Brushes.Black;
            rect.StrokeThickness = 2;
        }
        private void rect1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ClearBorders();
            Rectangle rect = (Rectangle)sender;
            rect.Stroke = Brushes.Black;
            rect.StrokeThickness = 2;
            SendPlayerColor(((SolidColorBrush)rect.Fill).Color, cbxPlayers.SelectedIndex);
        }

        private void ClearBorders()
        {
            rect1.Stroke = null;
            rect2.Stroke = null;
            rect3.Stroke = null;
            rect4.Stroke = null;
            rect5.Stroke = null;
            rect6.Stroke = null;
            rect7.Stroke = null;
            rect8.Stroke = null;
            rect9.Stroke = null;
            rect10.Stroke = null;
            rect11.Stroke = null;
            rect12.Stroke = null;
            rect13.Stroke = null;
            rect14.Stroke = null;
            rect15.Stroke = null;
            rect16.Stroke = null;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbxIt_Player1_Selected(object sender, RoutedEventArgs e)
        {
            GetPlayerColor(((ComboBoxItem)sender).Name.Substring(6));
        }
    }
}
