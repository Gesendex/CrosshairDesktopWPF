using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Draw = System.Drawing;

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
        public CustomCrosshair(int WidthCH, int HeightCH, int LineLenght, int LineWidth, int Gap, Color ColorCH)
        {
            TopLine = LeftLine = DownLine = RightLine = true;
            this.WidthCH = WidthCH;
            this.HeightCH = HeightCH;
            this.LineLenght = LineLenght;
            this.LineWidth = LineWidth;
            this.Gap = Gap;
            this.ColorCH = ColorCH;
            


        }
        public void UpdateImage()
        {
            CrosshairImage = new Draw.Bitmap(WidthCH, HeightCH);
            Draw.Point CenterCH = new Draw.Point(WidthCH / 2, HeightCH / 2);
        }
    }
}
