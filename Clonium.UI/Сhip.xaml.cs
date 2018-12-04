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
        public Сhip()
        {
            InitializeComponent();
        }

        public Сhip(Color color, int xc, int yc)
        {
            this.ChipBack.Background = new SolidColorBrush(color);
        }

        private void ChipBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //to Core function
        }

        private void Chip_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (CountPoints() == 0)
                Point1.Fill = Brushes.Black;
            if (CountPoints() == 1)
                Point2.Fill = Brushes.Black;
            if (CountPoints() == 2)
                Point3.Fill = Brushes.Black;
            //if (CountPoints() == 3)
        }


        private int CountPoints()
        {
            if (Point1.Fill == Brushes.Transparent && Point2.Fill == Brushes.Transparent && Point3.Fill == Brushes.Transparent)
                return 0;
            else if (Point1.Fill != Brushes.Transparent && Point2.Fill == Brushes.Transparent && Point3.Fill == Brushes.Transparent)
                return 1;
            else if (Point1.Fill != Brushes.Transparent && Point2.Fill != Brushes.Transparent && Point3.Fill == Brushes.Transparent)
                return 2;
            else if (Point1.Fill != Brushes.Transparent && Point2.Fill != Brushes.Transparent && Point3.Fill != Brushes.Transparent)
                return 3;
            else
                return -1;
        }
    }
}
