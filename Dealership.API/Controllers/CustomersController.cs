using Dealership.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dealership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly DealershipContext _context;
        public CustomersController(DealershipContext contex)
        {
            _context = contex;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("byPurchasedCarBrand")]
        public async Task<ActionResult> ListFilteredCustomerByCarBrand([FromQuery] string carBrand)
        {
            var customers = await _context.Customers.SelectMany(x => x.Orders).Where(x => x.Product.Brand.Equals(carBrand)).ToListAsync();
            return Ok(customers);
        }
    }
}
