using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Host_Hostess.Interfaces;
using Host_Hostess.Models.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Host_Hostess.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Host_HostessController : ControllerBase
    {
        IConfiguration Iconfiguration;
        IEventBus IeventBus;

        public Host_HostessController(IConfiguration configuration, IEventBus eventBus)
        {
            IeventBus = eventBus;
            Iconfiguration = configuration;
            eventBus.HostName = Iconfiguration["rabbitmqhostname"];
            eventBus.PortNumber = Convert.ToInt32(Iconfiguration["rabbitmqport"]);
        }

        [HttpGet]
        public ActionResult GetReservation()
        {
            return new JsonResult(IeventBus.ConsumeEvent("newReservation"));
        }

        [HttpPost]
        public ActionResult NewReservation([FromBody] ReservationTaken reservationTaken)
        {
            IeventBus.PublishEvent("newReservation", reservationTaken);

            return new JsonResult(reservationTaken);
        }

        [HttpGet]
        public ActionResult TableReady()
        {
            return new JsonResult(IeventBus.ConsumeEvent("tableReady"));
        }

        [HttpPost]
        public ActionResult SeatedTable([FromBody] SeatedTable seatedTable)
        {
            IeventBus.PublishEvent("seatedTable", seatedTable);

            return new JsonResult(seatedTable);
        }


    }
}
