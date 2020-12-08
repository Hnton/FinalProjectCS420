using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Waiter_Waitress.Interfaces;
using Waiter_Waitress.Models.Events;

namespace Waiter_Waitress.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Waiter_WaitressController : ControllerBase
    {
        IConfiguration Iconfiguration;
        IEventBus IeventBus;

        public Waiter_WaitressController(IConfiguration configuration, IEventBus eventBus)
        {
            IeventBus = eventBus;
            Iconfiguration = configuration;
            eventBus.HostName = Iconfiguration["rabbitmqhostname"];
            eventBus.PortNumber = Convert.ToInt32(Iconfiguration["rabbitmqport"]);
        }

        [HttpGet]
        public ActionResult SeatedTable()
        {
            return new JsonResult(IeventBus.ConsumeEvent("seatedTable"));
        }

        [HttpGet]
        public ActionResult ReadyToPay()
        {
            return new JsonResult(IeventBus.ConsumeEvent("readyToPay"));
        }

        [HttpGet]
        public ActionResult FoodReady()
        {
            return new JsonResult(IeventBus.ConsumeEvent("foodReady"));
        }

        [HttpGet]
        public ActionResult DrinkReady()
        {
            return new JsonResult(IeventBus.ConsumeEvent("drinkReady"));
        }

        [HttpPost]
        public ActionResult FoodOrder([FromBody] FoodOrder foodOrder)
        {
            IeventBus.PublishEvent("foodOrder", foodOrder);

            return new JsonResult(foodOrder);
        }

        [HttpPost]
        public ActionResult DrinkOrder([FromBody] DrinkOrder drinkOrder)
        {
            IeventBus.PublishEvent("drinkOrder", drinkOrder);

            return new JsonResult(drinkOrder);
        }

        [HttpPost]
        public ActionResult CheckPaid([FromBody] CheckPaid checkPaid)
        {
            IeventBus.PublishEvent("checkPaid", checkPaid);

            return new JsonResult(checkPaid);
        }


    }
}
