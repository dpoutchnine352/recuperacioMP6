using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace dpc.InternetSalesAPI
{
     [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            var customers = _customerService.GetCustomers();
            return Ok(customers);
        }

        [HttpGet("{DNI}")]
        public ActionResult<Customer> GetCustomer(string DNI)
        {
            var customer = _customerService.GetCustomerByDNI(DNI);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            _customerService.CreateCustomer(customer);
            return CreatedAtAction(nameof(GetCustomer), new { DNI = customer.DNI }, customer);
        }

        [HttpPut("{DNI}")]
    public async Task<IActionResult> UpdateCustomer(string DNI, [FromBody] Customer customer)
    {
        if (DNI != customer.DNI)
        {
            return BadRequest("DNI in URL does not match DNI in body");
        }

        try
        {
            await _customerService.UpdateCustomerAsync(customer);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

        [HttpDelete("{DNI}")]
        public IActionResult DeleteCustomer(string DNI)
        {
            var existingCustomer = _customerService.GetCustomerByDNI(DNI);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            _customerService.DeleteCustomer(DNI);
            return NoContent();
        }
    }
}
