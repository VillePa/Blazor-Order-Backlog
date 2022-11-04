using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using OrderBacklogApi.Data;
using SharedLib;

namespace OrderBacklogApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly OrderContext _db;

        public OrderController(ILogger<OrderController> logger, OrderContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("/orders")]
        public async Task<IEnumerable<Order>> Get()
        {

            return await _db.Orders.OrderBy(i => i.DeliveryDate).ToListAsync();

        }

        [HttpGet("/byState/{state}")]
        public async Task<IEnumerable<Order>> GetFinished(string state)
        {

            return await _db.Orders.OrderByDescending(i => i.Id).Where(s => s.State == state).ToListAsync();

        }

        [HttpGet("/orderById/{id}")]
        public async Task<ActionResult<Order>> GetCreated(Guid? id)
        {
            if (id != null) return await _db.Orders.Where(i => i.Id == id).FirstOrDefaultAsync();

            return NotFound();
        }

        [HttpPost("/order")]
        public async Task<IActionResult> AddOrder(OrderDTO item)
        {
            Order o = new Order();
            o.Id = Guid.NewGuid();

            o.State = item.State;
            o.OrderNumber = item.OrderNumber;
            o.EngineSpecification = item.EngineSpecification;
            o.EngineSerialNumber = item.EngineSerialNumber;
            o.EngineType1 = item.EngineType1;
            o.EngineType2 = item.EngineType2;
            o.Customer = item.Customer;
            o.OrderDate = item.OrderDate;
            o.DeliveryDate = item.DeliveryDate;

            _db.Orders.Add(o);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetCreated", new { id = o.Id }, o.ToDTO());
        }

        [HttpPut("/{id}")]
        public async Task<IActionResult> ChangeOrder(OrderDTO item)
        {
            var o = await _db.Orders.Where(i => i.Id == item.Id).FirstOrDefaultAsync();

            if (o == null) return NotFound();

            o.Id = item.Id;
            o.State = item.State;
            o.OrderNumber = item.OrderNumber;
            o.EngineSpecification = item.EngineSpecification;
            o.EngineSerialNumber = item.EngineSerialNumber;
            o.EngineType1 = item.EngineType1;
            o.EngineType2 = item.EngineType2;
            o.Customer = item.Customer;
            o.OrderDate = item.OrderDate;
            o.DeliveryDate = item.DeliveryDate;

            _db.Orders.Update(o);
            await _db.SaveChangesAsync();

            return Ok(o);
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> DeleteOrder(Guid? id)
        {
            var order = await _db.Orders.Where(i => i.Id == id).FirstOrDefaultAsync();

            if (order == null) return NotFound();

            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();

            return NoContent();

        }
    }
}
