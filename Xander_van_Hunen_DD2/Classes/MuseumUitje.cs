using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xander_van_Hunen_DD2.Classes
{
    internal class MuseumUitje: Uitje
    {
        // class variables
        public override string Name { get; set; }
        public override DateTime StartDate { get; set; } = DateTime.Now;
        public override bool Doorstroom { get; set; } = false;
        public override bool Binnenevent { get; set; } = true;
        public double Entry_price { get; set; }

        // constructor with 2 overloads
        public MuseumUitje(string name, DateTime StartDate, double Entry_price)
        {
            this.Name = name;
            this.StartDate = StartDate;
            this.Entry_price = Entry_price;
        }

        public MuseumUitje(string name, DateTime StartDate, bool doorstroom, bool binnenevent, double entry_price) : this (name, StartDate, entry_price)
        {
            Doorstroom = doorstroom;
            Binnenevent = binnenevent;
        }



        // functions
        public override bool VastePlaats()
        {
            return !Doorstroom;
        }

        public override bool Buiten()
        {
            return !Binnenevent;
        }

        public override bool CoronaCheckRequired()
        {
            // rules: outside = false || doorstroom = false.
            // other senarios will yield: true
            if (Doorstroom) return false;
            if (!Binnenevent) return false;
            return true;
        }

    }
}
