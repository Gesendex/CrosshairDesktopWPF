using CrosshairDesktopWPF.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrosshairDesktopWPF.ViewModels
{
    class MainWindowViewModel : BaseVM
    {
        public MainWindowViewModel()
        {
            DisplaySize = new Size(1920, 1080);
        }

        private Size DisplaySize;

        public int DisplayWidth
        {
            get { return DisplaySize.Width; }
            set { DisplaySize.Width = value; OnPropertyChanged(); }
        }

        public int DisplayHeight
        {
            get { return DisplaySize.Height; }
            set { DisplaySize.Height = value; OnPropertyChanged(); }
        }
    }
}
