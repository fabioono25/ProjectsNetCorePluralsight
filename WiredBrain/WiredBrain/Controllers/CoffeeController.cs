using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Net.WebSockets;
using System.Threading.Tasks;
using WiredBrain.Hubs;
using WiredBrain.Models;

namespace WiredBrain.Controllers
{
    [Route("[controller]")]
    public class CoffeeController : Controller
    {
        private readonly IHubContext<CoffeeHub> coffeeHub;

        public CoffeeController(IHubContext<CoffeeHub> coffeeHub)
        {
            this.coffeeHub = coffeeHub;
        }

        [HttpPost]
        public async Task<IActionResult> OrderCoffee(
            [FromBody] Order order)
        {
            await coffeeHub.Clients.All.SendAsync("NewOrder", order);
            //Save order somewhere and get order id
            return Accepted(1); //return order id
        }
    }
}
