using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waiter_Waitress.Models.Base;

namespace Waiter_Waitress.Models.Events
{
    public class SeatedTable : BaseEvent
    {
        public string TableNumber { get; set; }

        public int TotalGuests { get; set; }


    }
}

// Consumed Event