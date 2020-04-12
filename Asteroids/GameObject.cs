using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Asteroids
{
    abstract class GameObject    //később abstract lesz
    {
        double x;
        double y;
        double vx;
        double vy;

        public double X
        { get { return x; } }

        public double Y
        { get { return y; } }

        public double VX
        { get { return vx; } set { vx = value; } }

        public double VY
        { get { return vy; } set { vy = value; } }

        public GameObject(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public GameObject(double x, double y, double vx, double vy)
        {
            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;
        }

        public abstract void Draw(Canvas drawingArea);

        //igaz, amikor kimegy a képernyőröl
        public bool Animation(TimeSpan interval, Canvas drawingArea)
        {
            x += vx * interval.TotalSeconds;
            y += vy * interval.TotalSeconds;

            bool overTheEdge = false;
                if (x < 0.0)
                    {
                overTheEdge = true;
                x = drawingArea.ActualWidth;
                    }
                else if(x > drawingArea.ActualWidth)
                    {
                overTheEdge = true;
                x = 0.0;
                    }
                if (y < 0.0)
                    {
                overTheEdge = true;
                y = drawingArea.ActualHeight;
                    }
                else if (y > drawingArea.ActualHeight )
                    {
                overTheEdge = true;
                y = 0.0;
                    }
            return overTheEdge;
        }
    }

    class Asteroid : GameObject
    {
        static Random random = new Random();
        
        Polygon asteroids = new Polygon();

        public Asteroid(Canvas drawingArea)     //(méretezés)
            : base(random.NextDouble() * drawingArea.ActualWidth,
                  random.NextDouble() * drawingArea.ActualHeight,
                  (random.NextDouble() - 0.5)* 100.0,
                  (random.NextDouble() - 0.5)* 100)
        {
            for (int i = 0; i < 20; i++)
            {
                double szog = 2.0 * Math.PI / 20.0 * i;
                double radius = 8.0 + 4.0 * random.NextDouble();
                asteroids.Points.Add(new System.Windows.Point(radius * Math.Cos(szog), radius * Math.Sin(szog)));
            }
            asteroids.Fill = Brushes.Gray;
        }

        public override void Draw(Canvas drawingArea)
        {
            drawingArea.Children.Add(asteroids);
            Canvas.SetLeft(asteroids, X);
            Canvas.SetTop(asteroids, Y);
        }

        public bool ContainsPoint(double x, double y)
        {
            return asteroids.RenderedGeometry.FillContains(new System.Windows.Point(x - X, y - Y));
        }
    }

    class SpaceShip : GameObject
    {
        Polygon ship = new Polygon();

        public SpaceShip(Canvas drawingArea)
            : base(0.5 * drawingArea.ActualWidth, 0.5 * drawingArea.ActualHeight, 3.0, 5.0)
        {
            ship.Points.Add(new System.Windows.Point(0.0, -10.0));
            ship.Points.Add(new System.Windows.Point(5.0, 7.0));
            ship.Points.Add(new System.Windows.Point(-5.0, 7.0));
            ship.Fill = Brushes.Blue;
        }

        public override void Draw(Canvas drawingArea)
        {
            double angleInDegree = Math.Atan2(VY, VX) * 180.0 / Math.PI + 90.0;
            ship.RenderTransform = new RotateTransform(angleInDegree);
            drawingArea.Children.Add(ship);
            Canvas.SetLeft(ship, X);
            Canvas.SetTop(ship, Y);
        }

        public void TurnLeft(bool toLeft)
        {
            double angle = (toLeft ? -5.0 : 5.0) * Math.PI / 180.0;
            double vxNew = Math.Cos(angle) * VX - Math.Sin(angle) * VY;
            VY = Math.Sin(angle) * VX + Math.Cos(angle) * VY;
            VX = vxNew;
        }

        internal void Accelerate(bool accelerate)
        {
            double faktor = accelerate ? 1.1 : 0.9;
            VX *= faktor;
            VY *= faktor;
        }
    }

    class LaserShooting : GameObject
    {
        public LaserShooting(SpaceShip spaceShip)
            :base (spaceShip.X, spaceShip.Y, 1.5 * spaceShip.VX, 1.5 * spaceShip.VY)
        {
        }
        public override void Draw(Canvas drawingArea)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = 6.0;
            ellipse.Height = 6.0;
            ellipse.Fill = Brushes.Red;
            drawingArea.Children.Add(ellipse);
            Canvas.SetLeft(ellipse, X + 0.5 * ellipse.Width);
            Canvas.SetTop(ellipse, Y + 0.5 * ellipse.Height);
        }
    }
}
