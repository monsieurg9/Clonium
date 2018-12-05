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
    /// Логика взаимодействия для Player.xaml
    /// </summary>
    public partial class Player : UserControl
    {
        public Player()
        {
            InitializeComponent();
        }

        public Player(Color color, bool isActive)
        {
            InitializeComponent();
            Head.Fill = new SolidColorBrush(color);
            Body.Fill = new SolidColorBrush(color);
            ChangeTurn(isActive);
        }

        public void ChangeTurn(bool isActive)
        {
            if (isActive)
                this.rectIsActive.Fill = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            else
                this.rectIsActive.Fill = null;
        }
    }
}
