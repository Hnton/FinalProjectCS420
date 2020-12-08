using Host_Hostess.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Host_Hostess.Models.Events
{
    public class Reservation : BaseEvent
    {
        public int TotalGuest { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }



    }
}

// Consumed Event