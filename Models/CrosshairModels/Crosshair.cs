using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Draw = System.Drawing;

namespace CrosshairDesktopWPF.Models.CrosshairModels
{
    public abstract class Crosshair
    {
        public Draw.Image CrosshairImage { get; set; }
    }
}
