using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBoys.Interfaces;
using BusBoys.Models.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BusBoys.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BusBoysController : ControllerBase
    {

        IConfiguration Iconfiguration;
        IEventBus IeventBus;

        public BusBoysController(IConfiguration configuration, IEventBus eventBus)
        {
            IeventBus = eventBus;
            Iconfiguration = configuration;
            eventBus.HostName = Iconfiguration["rabbitmqhostname"];
            eventBus.PortNumber = Convert.ToInt32(Iconfiguration["rabbitmqport"]);
        }

        [HttpGet]
        public ActionResult CheckPaid()
        {
            return new JsonResult(IeventBus.ConsumeEvent("checkPaid"));
        }

        [HttpPost]
        public ActionResult TableReady([FromBody] TableReady tableReady)
        {
            IeventBus.PublishEvent("tableReady", tableReady);

            return new JsonResult(tableReady);
        }
    }
}
