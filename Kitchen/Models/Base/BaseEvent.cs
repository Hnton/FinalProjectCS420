using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kitchen.Models.Base
{
    public class BaseEvent
    {
        public int OrderNumber { get; set; }

        public string TableNumber { get; set; }

        public Dictionary<string, double> Food { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}
