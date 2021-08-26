using CrosshairDesktopWPF.Core;
using CrosshairDesktopWPF.Models.CrosshairModels;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CrosshairDesktopWPF.Views;
using System.Windows.Media.Imaging;
using System.IO;

namespace CrosshairDesktopWPF.ViewModels
{
    class MainWindowViewModel : BaseVM
    {
        #region Commands
        public RelayCommand OpenCrosshairWindow { get; set; }
        public RelayCommand CloseCrosshairWindow { get; set; }
        #endregion
        #region Properties
        #region DisplaySize
        private Size DisplaySize;
        public double DisplayWidth
        {
            get { return DisplaySize.Width; }
            set { DisplaySize.Width = value; OnPropertyChanged(); }
        }

        public double DisplayHeight
        {
            get { return DisplaySize.Height; }
            set { DisplaySize.Height = value; OnPropertyChanged(); }
        }
        #endregion
        #region _currentCross
        private CustomCrosshair _currentCross;
        public int WidthCH
        {
            get { return _currentCross.WidthCH; }
            set { _currentCross.WidthCH = value; OnPropertyChanged(); }
        }
        public int HeightCH
        {
            get { return _currentCross.HeightCH; }
            set { _currentCross.HeightCH = value; OnPropertyChanged(); }
        }

        public int Lenght
        {
            get { return _currentCross.LineLenght; }
            set { _currentCross.LineLenght = value; OnPropertyChanged(); }
        }
        public int Width
        {
            get { return _currentCross.LineWidth; }
            set { _currentCross.LineWidth = value; OnPropertyChanged(); }
        }
        public int Gap
        {
            get { return _currentCross.Gap; }
            set { _currentCross.Gap = value; OnPropertyChanged(); }
        }

        public System.Windows.Media.Color ColorCH
        {
            get { return _currentCross.ColorCH; }
            set { _currentCross.ColorCH = value; OnPropertyChanged(); }
        }
        #endregion
        #region IsCrossWindowOpen
        public bool IsCrossWindowClosed
        {
            get { return CrossWindow == null; }
        }
        #endregion
        #region CrossWindow
        public CrosshairWindow CrossWindow { get; set; }
        #endregion
        #endregion
        
        public MainWindowViewModel()
        {
            OpenCrosshairWindow = new RelayCommand(o =>
            {
                CrossWindow = new CrosshairWindow();
                CrossWindow.WindowStartupLocation = WindowStartupLocation.Manual;
                CrossWindow.Top = (DisplayHeight - _currentCross.HeightCH) / 2;
                CrossWindow.Left = (DisplayWidth - _currentCross.WidthCH) / 2;
                OnPropertyChanged("IsCrossWindowClosed");
                CrossWindow.Height = CrossWindow.Width = _currentCross.WidthCH;
                string current = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CurrentCross.png");
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(current);
                image.EndInit();
                CrossWindow.im.BeginInit();
                CrossWindow.im.Stretch = Stretch.Fill;
                CrossWindow.im.Source = image;
                Drawing drawing = new ImageDrawing(image, new Rect(0, 0, _currentCross.WidthCH, _currentCross.HeightCH));
                CrossWindow.Background = new DrawingBrush(drawing);


                CrossWindow.Show();
            });
            CloseCrosshairWindow = new RelayCommand(o =>
            {
                if (CrossWindow != null)
                {
                    CrossWindow.Close();
                    CrossWindow = null;
                    string current = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CurrentCross.png");
                    OnPropertyChanged("IsCrossWindowClosed");
                }
            });
            DisplaySize = new Size(1920, 1080);
            _currentCross = new CustomCrosshair(150, 150, 10, 3, 4, Color.FromRgb(0,0,0));
        }
    }
}
