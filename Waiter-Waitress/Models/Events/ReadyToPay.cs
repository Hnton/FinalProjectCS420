using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Waiter_Waitress.Models.Events
{
    public class ReadyToPay
    {
        public int OrderNumber { get; set; }

        public string TableNumber { get; set; }

        public Dictionary<string, double> Drink { get; set; }
        public Dictionary<string, double> Food { get; set; }


    }
}

// Consumed Event