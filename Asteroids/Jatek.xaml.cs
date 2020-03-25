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

namespace Asteroids
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down && Canvas.GetTop(rec1) + rec1.Height < 420)
            {
                Canvas.SetTop(rec1, Canvas.GetTop(rec1) + 10);
            }
            else if (e.Key == Key.Up && Canvas.GetTop(rec1) > 0)
            {
                Canvas.SetTop(rec1, Canvas.GetTop(rec1) - 10);
            }
            else if (e.Key == Key.Left && Canvas.GetLeft(rec1) > 0)
            {
                Canvas.SetLeft(rec1, Canvas.GetLeft(rec1) - 10);
            }
            else if (e.Key == Key.Right && Canvas.GetLeft(rec1) + rec1.Width < 790)
            {
                Canvas.SetLeft(rec1, Canvas.GetLeft(rec1) + 10);
            }
           
        }
    }
}
