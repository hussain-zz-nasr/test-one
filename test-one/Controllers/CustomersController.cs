using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test_one.Data;
using test_one.Model;

namespace test_one.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly test_oneContext _context;

        public CustomersController(test_oneContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetCustomer([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            // Validate input
            if (page <= 0 || pageSize <= 0)
            {
                return BadRequest("Page and pageSize must be greater than 0.");
            }

            var totalCustomers = await _context.Customer.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCustomers / (double)pageSize);

            var customers = await _context.Customer
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(new
            {
                page,
                pageSize,
                totalCustomers,
                totalPages,
                customers
            });
        }
        //    [HttpGet]
        //    public async Task<ActionResult<object>> GetCustomer(
        //[FromQuery] int page = 1,
        //[FromQuery] int pageSize = 5,
        //[FromQuery] string? search = null)
        //    {
        //        var query = _context.Customer.AsQueryable();

        //        if (!string.IsNullOrEmpty(search))
        //        {
        //            search = search.ToLower();
        //            query = query.Where(c =>
        //                c.Name.ToLower().Contains(search) ||
        //                c.Number.ToLower().Contains(search) ||
        //                c.Email.ToLower().Contains(search) ||
        //                c.Address.ToLower().Contains(search));
        //        }

        //        var totalCustomers = await query.CountAsync();
        //        var totalPages = (int)Math.Ceiling(totalCustomers / (double)pageSize);

        //        var customers = await query
        //            .Skip((page - 1) * pageSize)
        //            .Take(pageSize)
        //            .ToListAsync();

        //        return Ok(new { page, pageSize, totalCustomers, totalPages, customers });
        //    }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
