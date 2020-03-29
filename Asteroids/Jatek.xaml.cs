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
    //TESZT
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int valami = 10;
        String merreFordul = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down && Canvas.GetTop(hajo) + hajo.Height < 420)
            {
                Canvas.SetTop(hajo, Canvas.GetTop(hajo) + 10);
                hajo.Source = new BitmapImage(new Uri("hajoLe.jpg", UriKind.RelativeOrAbsolute));
                merreFordul = "le";
            }
            else if (e.Key == Key.Up && Canvas.GetTop(hajo) > 0)
            {
                Canvas.SetTop(hajo, Canvas.GetTop(hajo) - 10);
                hajo.Source = new BitmapImage(new Uri("hajoFel.jpg", UriKind.RelativeOrAbsolute));
                merreFordul = "fel";
            }
            else if (e.Key == Key.Left && Canvas.GetLeft(hajo) > 0)
            {
                Canvas.SetLeft(hajo, Canvas.GetLeft(hajo) - 10);
                hajo.Source = new BitmapImage(new Uri("hajoBalra.jpg", UriKind.RelativeOrAbsolute));
                merreFordul = "balra";
            }
            else if (e.Key == Key.Right && Canvas.GetLeft(hajo) + hajo.Width < 790)
            {
                Canvas.SetLeft(hajo, Canvas.GetLeft(hajo) + 10);
                hajo.Source = new BitmapImage(new Uri("hajoJobbra.jpg", UriKind.RelativeOrAbsolute));
                merreFordul = "jobbra";
            }
            else if (e.Key == Key.Escape)
                Close();
           
        }
    }
}
