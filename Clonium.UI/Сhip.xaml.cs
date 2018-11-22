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
    }
}
