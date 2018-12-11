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
        Border border;
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void GetPlayerColor(string player)
        {
            //to core
        }

        private void SendPlayerColor(Color color)
        {
            //to core
        }

        private void rect1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ClearBorders();
            Rectangle rect = (Rectangle)sender;
            rect.Stroke = Brushes.Black;
            rect.StrokeThickness = 2;
            SendPlayerColor(((SolidColorBrush)rect.Fill).Color);
        }

        private void ClearBorders()
        {
            //for (int i = 1; i <= 16; i++)
            //{

            //}

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
