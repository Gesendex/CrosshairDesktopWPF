using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CrosshairDesktopWPF.Models.CanvasDraw
{
    public static class GeometryFigure
    {
        public static Rectangle CreateRectangle( int left, int top, int width, int height, int strokeThickness, Brush bFill, Brush bStroke = null)
        {
            var rect = new Rectangle();
            rect.Fill = bFill;
            rect.Width = width;
            rect.Height = height;
            if (bStroke != null) rect.Stroke = bStroke;
            rect.StrokeThickness = strokeThickness;
            Canvas.SetLeft(rect, left);
            Canvas.SetTop(rect, top);

            return rect;
        }
    }
}
