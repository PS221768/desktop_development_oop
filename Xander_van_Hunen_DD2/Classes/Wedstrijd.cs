using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xander_van_Hunen_DD2.Classes
{
    internal abstract class Wedstrijd
    {
        // class variables
        public abstract string Name { get; set; }
        public abstract DateTime StartDate { get; set; }
        public abstract int Duration { get; set; } // in secconds
    }
}
