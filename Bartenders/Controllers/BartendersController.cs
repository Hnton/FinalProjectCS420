using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bartenders.Interfaces;
using Bartenders.Models.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Bartenders.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BartendersController : ControllerBase
    {
        IConfiguration Iconfiguration;
        IEventBus IeventBus;

        public BartendersController(IConfiguration configuration, IEventBus eventBus)
        {
            IeventBus = eventBus;
            Iconfiguration = configuration;
            eventBus.HostName = Iconfiguration["rabbitmqhostname"];
            eventBus.PortNumber = Convert.ToInt32(Iconfiguration["rabbitmqport"]);
        }

        [HttpGet]
        public ActionResult DrinkOrder()
        {
            return new JsonResult(IeventBus.ConsumeEvent("drinkOrder"));
        }

        [HttpPost]
        public ActionResult DrinkReady([FromBody] DrinkReady drinkReady)
        {
            IeventBus.PublishEvent("drinkReady", drinkReady);

            return new JsonResult(drinkReady);
        }
    }
}
