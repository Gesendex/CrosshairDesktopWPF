using CrosshairDesktopWPF.Models.CanvasDraw;
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

namespace CrosshairDesktopWPF.Views
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var center = new Point(20, 20);
            double[] mas = new double[8];
            mas[0] = center.X - 10;
            mas[1] = center.X - 5;
            mas[2] = center.X + 10;
            mas[3] = center.X + 5;
            mas[4] = center.Y - 10;
            mas[5] = center.Y - 5;
            mas[6] = center.Y + 10;
            mas[7] = center.Y + 5;
            cnvCanvas.Children.Insert(0, GeometryFigure.CreateRectangle(0, 0, 150, 150, 30, Brushes.Cyan, Brushes.Red));
        }
    }

}
