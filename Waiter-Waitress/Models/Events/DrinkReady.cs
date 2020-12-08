using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waiter_Waitress.Models.Base;

namespace Waiter_Waitress.Models.Events
{
    public class DrinkReady : BaseEvent
    {
        public int OrderNumber { get; set; }

        public string TableNumber { get; set; }

        public Dictionary<string, double> Drink { get; set; }


    }
}

// Consumed Event