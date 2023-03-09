using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xander_van_Hunen_DD2.Classes
{
    internal class BuitenWedstrijd : Wedstrijd, ICoronaCheckEvenement
    {
        // class variables
        public override string Name { get; set; }
        public override DateTime StartDate { get; set; }
        public override int Duration { get; set; } // in secconds
        public bool Doorstroom { get; set; }

        // contructor
        public BuitenWedstrijd(string name, DateTime startDate, int duration, bool doorstroom)
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
            return true; // as stated in the name, it is an outdoors game.
        }

        public bool CoronaCheckRequired()
        {
            return false; // as this is outside it will default to false
        }
    }
}
