using Host_Hostess.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Host_Hostess.Models.Events
{
    public class TableReady : BaseEvent
    {
        public string TableNumber { get; set; }
        public int SeatCount { get; set; }
    }
}

// Consumed Event