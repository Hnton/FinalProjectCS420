using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waiter_Waitress.Models.Base;

namespace Waiter_Waitress.Models.Events
{
    public class CheckPaid : BaseEvent
    {
        public string TableNumber { get; set; }


    }
}

// Published Event