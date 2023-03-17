using Dealership.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dealership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly DealershipContext _context;
        public CarsController(DealershipContext contex)
        {
            _context = contex;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            var products = _context.Products.ToArrayAsync();
            return Ok(products);
        }

        [HttpGet("models")]
        public async Task<ActionResult> GetAllProductModels()
        {
            var products = await _context.Products.Select(x => x.CarModel).ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();

            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetProduct",
                new
                {
                    id = product.Id
                },
                product
                );
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            _context.Entry(product).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(p => p.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult> DeleteMultipleObjects([FromQuery] int[] ids)
        {
            var products = new List<Product>();

            foreach (int id in ids)
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound(id);
                }
                products.Add(product);
            }

            _context.Products.RemoveRange(products);
            await _context.SaveChangesAsync();
            return Ok(products);
        }

        [HttpPost]
        [Route("{id}/purchase")]
        public async Task<ActionResult> PurchaseCar([FromRoute] int id, [FromQuery] int customerId)
        {
            var order = new Order()
            {
                ProductId = id,
                CreatedAt = DateTime.UtcNow,
                CustomerId = customerId
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
