using CrosshairDesktopWPF.Core;
using CrosshairDesktopWPF.Models.CanvasDraw;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
        public double Center { get; set; }
        public bool InitFlag { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            DrawCross();
            InitFlag = true;
        }

        private void DrawCross()
        {
            Center = cnvCanvas.ActualWidth / 2;
            var cpBrush = new SolidColorBrush(cpColor.SelectedColor);
            cnvCanvas.Children.Clear();
            cnvCanvas.Children.Add(GeometryFigure.CreateRectangle(0, 0, (int)cnvCanvas.ActualWidth, (int)cnvCanvas.ActualHeight, 0, Brushes.Transparent));
            if ((bool)chbArrowUp.IsChecked)
            {
                cnvCanvas.Children.Add(GeometryFigure.CreateRectangle(Center - sldrWidth.Value / 2, 
                                                                        Center - (sldrGap.Value + sldrLen.Value), 
                                                                        sldrWidth.Value, 
                                                                        sldrLen.Value, 
                                                                        0, cpBrush));
            }

            if ((bool)chbArrowLeftf.IsChecked)
            {
                cnvCanvas.Children.Add(GeometryFigure.CreateRectangle(Center - (sldrLen.Value + sldrGap.Value),
                                                                        Center - sldrWidth.Value/ 2,
                                                                        sldrLen.Value, 
                                                                        sldrWidth.Value,
                                                                        0, cpBrush));
            }

            if ((bool)chbArrowDown.IsChecked)
            {
                cnvCanvas.Children.Add(GeometryFigure.CreateRectangle(Center - sldrWidth.Value/ 2, 
                                                                        Center + sldrGap.Value,
                                                                        sldrWidth.Value,
                                                                        sldrLen.Value,
                                                                        0, cpBrush));
            }

            if ((bool)chbArrowRight.IsChecked)
            {
                cnvCanvas.Children.Add(GeometryFigure.CreateRectangle(Center + sldrGap.Value,
                                                                        Center - sldrWidth.Value/ 2,
                                                                        sldrLen.Value,
                                                                        sldrWidth.Value,
                                                                        0, cpBrush));
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
            ToImageSource(cnvCanvas, System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CurrentCross.png"));
            spCanvas.InvalidateArrange();//Необходимо для того, чтобы после сохранения не канвас не менял местоположение
        }

        private void Cross_ShapeChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(InitFlag)
                DrawCross();
        }

        private void Cross_Changed(object sender, RoutedEventArgs e)
        {
            if (InitFlag)
                DrawCross();
        }

        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btMinimize_Click(object sender, RoutedEventArgs e)
        {
                WindowState = WindowState.Minimized;
        }
    }

}
