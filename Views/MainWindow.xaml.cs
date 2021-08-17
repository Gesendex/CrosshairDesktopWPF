using CrosshairDesktopWPF.Models.CanvasDraw;
using System;
using System.Collections.Generic;
using System.IO;
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
            DrawCross();
        }

        private void DrawCross()
        {
            cnvCanvas.Children.Insert(0, GeometryFigure.CreateRectangle(0, 0, (int)cnvCanvas.ActualWidth, (int)cnvCanvas.ActualHeight, 0, Brushes.Transparent));
            cnvCanvas.Children.Insert(1, GeometryFigure.CreateRectangle(25, 25, 100, 100, 0, Brushes.Cyan));
        }
        private void SaveCanvasImage()
        {
            Microsoft.Win32.SaveFileDialog saveimg = new Microsoft.Win32.SaveFileDialog();
            saveimg.DefaultExt = ".PNG";
            saveimg.Filter = "Image (.PNG)|*.PNG";
            if (saveimg.ShowDialog() == true)
            {
                ToImageSource(cnvCanvas, saveimg.FileName);
            }
        }
        public static void ToImageSource(Canvas canvas, string filename)
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)canvas.ActualWidth, (int)canvas.ActualHeight, 96d, 96d, PixelFormats.Pbgra32);
            canvas.Measure(new Size((int)canvas.ActualWidth, (int)canvas.ActualHeight));
            canvas.Arrange(new Rect(new Size((int)canvas.ActualWidth, (int)canvas.ActualHeight)));
            bmp.Render(canvas);
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            using (FileStream file = File.Create(filename))
            {
                encoder.Save(file);
            }
            canvas.HorizontalAlignment = HorizontalAlignment.Center;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveCanvasImage();
            spCanvas.InvalidateArrange();
        }
    }

}
