using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xander_van_Hunen_DD2.Classes
{
    public interface ICoronaCheckEvenement
    {
        // added this, as every single object has it. And it makes it more easy for me to implement a feature in the main program
        string Name { get; set; }
        
        bool VastePlaats();
        bool Buiten();
        bool CoronaCheckRequired();
    }
}
