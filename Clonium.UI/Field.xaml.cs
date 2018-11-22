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
    /// Логика взаимодействия для Field.xaml
    /// </summary>
    public partial class Field : UserControl
    {

        int size;
        public int FieldSize { get { return this.size; } }

        public Field()
        {
            InitializeComponent();
        }

        public Field(int fieldSize)
        {
            this.size = fieldSize;
            for (int i = 0; i < fieldSize; i++)
            {
                this.Field1.ColumnDefinitions.Add(new ColumnDefinition());
                this.Field1.RowDefinitions.Add(new RowDefinition());
            }
        }
    }
}
