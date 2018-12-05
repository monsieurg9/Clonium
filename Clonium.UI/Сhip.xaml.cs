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
    /// Логика взаимодействия для Сhip.xaml
    /// </summary>
    public partial class Сhip : UserControl
    {
        MainWindow main;
        public Сhip()
        {
            InitializeComponent();
        }

        public Сhip(Color color, int dotNumber, MainWindow mainWindow)
        {
            InitializeComponent();
            main = mainWindow;
            this.ChipBack.Background = new SolidColorBrush(color);
            if (dotNumber==1)
            {
                this.Point1.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
            else if (dotNumber == 2)
            {
                this.Point1.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                this.Point2.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
            else if (dotNumber == 3)
            {
                this.Point1.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                this.Point2.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                this.Point3.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
        }

        private void ChipBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main.OpenChip(this);
        }

        private void ChipControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main.OpenChip(this);
        }
    }
}
