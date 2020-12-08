using BusBoys.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBoys.Models.Events
{
    public class TableReady : BaseEvent
    {
        public int SeatCount { get; set; }
    }
}

// Published Event