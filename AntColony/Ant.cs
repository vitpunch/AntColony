using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AntColony
{
    internal interface Ant
    {
        public int X { get;  }
        public int Y { get;  }
        int Direction { get; set; }
        
        public void Go();
    }
}
