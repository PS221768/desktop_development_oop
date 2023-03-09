using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xander_van_Hunen_DD2.Classes
{
    internal class BinnenWedstrijd : Wedstrijd, ICoronaCheckEvenement
    {
        // class variables
        public override string Name { get; set; }
        public override DateTime StartDate { get; set; }
        public override int Duration { get; set; } // in secconds
        public bool Doorstroom { get; set; }

        // contructor
        public BinnenWedstrijd(string name, DateTime startDate, int duration, bool doorstroom)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.Duration = duration;
            this.Doorstroom = doorstroom;
        }


        // functions
        public bool VastePlaats()
        {
            return !Doorstroom;
        }

        public bool Buiten()
        {
            return false; // as stated in the name, it is an indoors game.
        }

        public bool CoronaCheckRequired()
        {
            // rules: outside = false || doorstroom = false.
            // other senarios will yield: true
            if (Doorstroom) return false;
            return true;
        }
    }
}
