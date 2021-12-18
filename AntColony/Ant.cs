using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntColony
{
    internal interface Ant
    {
        public double X { get; set; }
        public double Y { get; set; }
        double Direction { get; set; }
        
        public void Go();
    }
}
