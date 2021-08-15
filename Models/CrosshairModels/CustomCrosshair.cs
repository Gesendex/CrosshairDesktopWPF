using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrosshairDesktopWPF.Models.CrosshairModels
{
    public class CustomCrosshair : Crosshair
    {
        public int WidthCH { get; set; }
        public int HeightCH { get; set; }
        public bool TopLine { get; set; }
        public bool LeftLine { get; set; }
        public bool DownLine { get; set; }
        public bool RightLine { get; set; }
        public int LineLenght { get; set; }
        public int LineWidth { get; set; }
        public int Gap { get; set; }
        public Color ColorCH { get; set; }
        public CustomCrosshair()
        {
            TopLine = LeftLine = DownLine = RightLine = true;
        }
    }
}
