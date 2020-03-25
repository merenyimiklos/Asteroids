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

namespace Asteroids
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void buttonLeallitas_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonElinditas_Click(object sender, RoutedEventArgs e)
        {
            MainWindow jatek = new MainWindow();
            jatek.ShowDialog();
        }
    }
}