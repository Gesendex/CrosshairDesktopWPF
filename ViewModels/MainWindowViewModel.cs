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

namespace CrosshairDesktopWPF.ViewModels
{
    class MainWindowViewModel : BaseVM
    {
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
        #region cnvCanvas
        private Canvas _cnvCanvas;

        public Canvas CnvCanvas
        {
            get { return _cnvCanvas; }
            set { _cnvCanvas = value; }
        }

        #endregion
        #endregion

        #region Commands
        #endregion
        public MainWindowViewModel()
        {
            DisplaySize = new Size(1920, 1080);
            _currentCross = new CustomCrosshair(40, 40, 10, 3, 4, Color.FromRgb(0,0,0));
        }
    }
}
