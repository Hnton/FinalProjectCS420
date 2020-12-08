using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bartenders.Models.Base
{
    public class BaseEvent
    {
        public DateTime TimeStamp { get; set; }

        public int OrderNumber { get; set; }

        public string TableNumber { get; set; }

        public Dictionary<string, double> Drink { get; set; }

    }
}
