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
using System.Windows.Threading;

namespace SolarSystem75
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += Update;
            timer.Start();
        }
        double angle = 0;
        void Update(object sender, EventArgs e)
            {
                if (Canvas.Width == 0 || Canvas.Height == 0)
                    return;
                
                Orbit(Mercury, 100, angle);
                Orbit(Venus, 150, angle + 70);
                Orbit(Earth, 200, angle + 170);
                Orbit(Mars, 300, angle + 250);

                if (angle >= 360)
                    angle = 0;
                else
                    angle += 1;  
            }
            void Orbit(Shape shape, double distance, double degrees)
            {
                double radians = degrees * Math.PI / 180;
                double x = distance * Math.Cos(radians);
                double y = distance * Math.Sin(radians);
                Canvas.SetLeft(shape, x + 300);
                Canvas.SetTop(shape, y + 300);
        }
    }
}
