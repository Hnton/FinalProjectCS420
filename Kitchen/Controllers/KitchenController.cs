using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.Interfaces;
using Kitchen.Models.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Kitchen.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class KitchenController : ControllerBase
    {
        IConfiguration Iconfiguration;
        IEventBus IeventBus;

        public KitchenController(IConfiguration configuration, IEventBus eventBus)
        {
            IeventBus = eventBus;
            Iconfiguration = configuration;
            eventBus.HostName = Iconfiguration["rabbitmqhostname"];
            eventBus.PortNumber = Convert.ToInt32(Iconfiguration["rabbitmqport"]);
        }

        [HttpGet]
        public ActionResult GetFoodOrder()
        {
            return new JsonResult(IeventBus.ConsumeEvent("foodOrder"));
        }


        [HttpPost]
        public ActionResult FoodReady([FromBody] FoodReady foodReady)
        {
            IeventBus.PublishEvent("foodReady", foodReady);

            return new JsonResult(foodReady);
        }

    }
}
