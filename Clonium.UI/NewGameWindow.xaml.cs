﻿using System;
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
    /// Логика взаимодействия для NewGameWindow.xaml
    /// </summary>
    public partial class NewGameWindow : Window
    {
        MainWindow main;
        public NewGameWindow()
        {
            InitializeComponent();
        }
        public NewGameWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            main = mainWindow;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            main.Activate();
            main.StartGame();
        }
    }
}
