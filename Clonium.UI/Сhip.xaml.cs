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
    /// Логика взаимодействия для Сhip.xaml
    /// </summary>
    /// 

    public delegate void FillChipHanlder(int xc, int yc);
    public delegate void SetPointsHandler(int pointsCount, int xc, int yc);
    public partial class UIСhip : UserControl
    {
        public UIСhip()
        {
            InitializeComponent();
        }

        int clickCount = 0;

        public event FillChipHanlder FilledChip;
        public event SetPointsHandler SetPoints;

        public UIСhip(Color color, int dotNumber)
        {
            InitializeComponent();
            this.btnChip.Background = new SolidColorBrush(color);
            this.Point1.Fill = Brushes.Transparent;
            this.Point2.Fill = Brushes.Transparent;
            this.Point3.Fill = Brushes.Transparent;
            clickCount = dotNumber;
            if (dotNumber == 1)
                this.Point1.Fill = Brushes.Black;
            if (dotNumber == 2)
            {
                this.Point1.Fill = Brushes.Black;
                this.Point2.Fill = Brushes.Black;
            }
            if (dotNumber == 3)
            {
                this.Point1.Fill = Brushes.Black;
                this.Point2.Fill = Brushes.Black;
                this.Point3.Fill = Brushes.Black;
            }
        }

        private void Chip_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MiddlewareLayer.GetMiddleware().FindPlayerByColor(((SolidColorBrush)this.btnChip.Background).Color))
            {
                clickCount++;
                if (CheckIsFullChip(clickCount))
                {
                    FilledChip.Invoke(Grid.GetColumn(this), Grid.GetRow(this));
                }
                else
                {
                    SetPoints.Invoke(clickCount, Grid.GetColumn(this), Grid.GetRow(this));
                }
                MiddlewareLayer.GetMiddleware().ChangeTurn();
            }
        }


        public int CountPoints()
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

        private bool CheckIsFullChip(int clickCount)
        {
            if (CountPoints() == 0)
            {
                Point1.Fill = Brushes.Black;
                return false;
            }
            else if (CountPoints() == 1)
            {
                Point2.Fill = Brushes.Black;
                return false;
            }
            else if (CountPoints() == 2)
            {
                Point3.Fill = Brushes.Black;
                return false;
            }
            else if (CountPoints() == 3 && clickCount == 3)
                return false;
            else
                return true;
        }
    }
}
