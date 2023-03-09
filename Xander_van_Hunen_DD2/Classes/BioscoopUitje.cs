using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xander_van_Hunen_DD2.Classes
{
    internal class BioscoopUitje: Uitje
    {
        // Class variables
        public override string Name { get; set; }
        public override DateTime StartDate { get; set; } = DateTime.Now;
        public override bool Doorstroom { get; set; } = false;
        public override bool Binnenevent { get; set; } = true;
        public DateTime StartTime { get; set; }
        public int Duration { get; set; } // in secconds
        public string Movie { get; set; }
        public string Room { get; set; }
        public string Seat { get; set; }

        // constructor with 2 overloads
        public BioscoopUitje(string name, DateTime startTime, int duration, string movie, string room, string seat)
        {
            this.Name = name;
            this.StartTime = startTime;
            this.Duration = duration;
            this.Movie = movie;
            this.Room = room;
            this.Seat = seat;
        }

        public BioscoopUitje(
            string name,
            DateTime startTime,
            int duration,
            string movie,
            string room,
            string seat,
            DateTime startDate) : this(name, startTime, duration, movie, room, seat)
        {
            this.StartDate = startDate;
        }

        public BioscoopUitje(
            string name,
            DateTime startTime,
            int duration,
            string movie,
            string room,
            string seat,
            DateTime startDate,
            bool doorstroom,
            bool binnenevent)
            : this(name, startTime, duration, movie, room, seat, startDate)
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
