using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PincherApp
{
    
    internal interface ISizable
    {
        public double CurrentWidth { get; set; }
        public double CurrentHeight { get; set; }

        public void UpdateSize(double Width, double Height);
    }
}
