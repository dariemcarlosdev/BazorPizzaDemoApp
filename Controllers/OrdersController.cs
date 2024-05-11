using BlazingPizzaNavigation.DAL;
using BlazingPizzaNavigation.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazingPizzaNavigation.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly PizzaStoreContext dbContext;

        public OrdersController(PizzaStoreContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderWithStatus>>> GetOrders()
        {
            var orders = dbContext.Orders
                .Include(o => o.Pizzas).ThenInclude(p => p.Special)
                .Include(o => o.Pizzas).ThenInclude(p => p.Toppings).ThenInclude(t => t.Topping)
                .OrderByDescending(o => o.CreatedTime).ToHashSet();
            // This is a LINQ Select query that applies the OrderWithStatus.FromOrder(o) method to each Order object in the orders collection.
            return orders.Select(o => OrderWithStatus.FromOrder(o)).ToList();
            
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<int>> PlacerOrder(Order order)
        {
            order.CreatedTime = DateTime.Now;

            // Enforce existence of Pizza.SpecialId and Topping.ToppingId
            // in the database - prevent the submitter from making up
            // new specials and toppings
            foreach (var pizza in order.Pizzas)
            {
                pizza.SpecialId = pizza.Special.Id;
                pizza.Special = null;
            }

            dbContext.Orders.Attach(order);
            await dbContext.SaveChangesAsync();

            return Ok(order.OrderId);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
