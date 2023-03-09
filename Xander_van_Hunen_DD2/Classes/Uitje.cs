using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xander_van_Hunen_DD2.Classes
{
    public abstract class Uitje : ICoronaCheckEvenement
    {
        // class variables
        public abstract string Name { get; set; }
        public abstract DateTime StartDate { get; set; }
        public abstract bool Doorstroom { get; set; }
        public abstract bool Binnenevent { get; set; }


        // class functions
        public abstract bool VastePlaats();

        public abstract bool Buiten();

        public abstract bool CoronaCheckRequired();

    }
}
