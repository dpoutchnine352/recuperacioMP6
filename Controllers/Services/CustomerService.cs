using System.Collections.Generic;
using System.Linq;
using dpc.InternetSalesAPI;
using Microsoft.EntityFrameworkCore;

namespace dpc.InternetSalesAPI
{
public class CustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerByDNI(string DNI)
        {
            return _context.Customers.Find(DNI);
        }

        public void CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public async Task UpdateCustomerAsync(Customer customer)
    {
        var existingCustomer = await _context.Customers
            .Include(c => c.Items)
                .ThenInclude(ci => ci.ItemObj)
            .FirstOrDefaultAsync(c => c.DNI == customer.DNI);

        if (existingCustomer == null)
        {
            throw new Exception("Customer not found");
        }

        // Update customer properties
        existingCustomer.Name = customer.Name;
        existingCustomer.Address = customer.Address;
        existingCustomer.Email = customer.Email;

        // Remove existing relationships
        _context.CustomerItems.RemoveRange(existingCustomer.Items);

        // Add updated relationships
        foreach (var ci in customer.Items)
        {
            var existingItem = await _context.Items.FindAsync(ci.ItemCode);
            if (existingItem == null)
            {
                throw new Exception($"Item with code {ci.ItemCode} not found");
            }

            existingCustomer.Items.Add(new CustomerItem
            {
                CustomerDNI = customer.DNI,
                ItemCode = ci.ItemCode,
                Quantity = ci.Quantity,
                Date = ci.Date,
                ItemObj = existingItem // Use the existing item
            });
        }

        await _context.SaveChangesAsync();
    }

        public void DeleteCustomer(string DNI)
        {
            var customer = _context.Customers.Find(DNI);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }
    }
}
