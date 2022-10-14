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

namespace SolarSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            /* Creating a timer that will call the Update function every millisecond. */
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += Update;
            timer.Start();
        }
        double angle = 0;
        /// <summary>
        /// > The function updates the position of the planets on the canvas by calling the Orbit function
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="EventArgs">This is a class that contains the event data.</param>
        /// <returns>
        /// The return type is void.
        /// </returns>
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
            /// <summary>
            /// It takes a shape, a distance, and a number of degrees, and then it sets the shape's position on the canvas
            /// to be the given distance away from the center of the canvas, at the given number of degrees
            /// </summary>
            /// <param name="Shape">The shape you want to orbit.</param>
            /// <param name="distance">The distance from the center of the canvas to the center of the shape.</param>
            /// <param name="degrees">The angle of the orbit in degrees.</param>
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
