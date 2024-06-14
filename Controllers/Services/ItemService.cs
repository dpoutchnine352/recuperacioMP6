using System.Collections.Generic;
using System.Threading.Tasks;
using dpc.InternetSalesAPI;
using Microsoft.EntityFrameworkCore;

namespace dpc.InternetSalesAPI
{
public class ItemService
    {
        private readonly DataContext _context;

        public ItemService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public Item GetItemByCode(string code)
        {
            return _context.Items.Find(code);
        }

        public void CreateItem(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }

  public async Task UpdateItemAsync(Item item)
    {
        var existingItem = await _context.Items
            .Include(i => i.Customers)
                .ThenInclude(ci => ci.CustomerObj)
            .FirstOrDefaultAsync(i => i.Code == item.Code);

        if (existingItem == null)
        {
            throw new Exception("Customer not found");
        }

        // Update customer properties
        existingItem.Name = item.Name;
        existingItem.Price = item.Price;

        // Remove existing relationships
        _context.CustomerItems.RemoveRange(existingItem.Customers);

        // Add updated relationships
        foreach (var ci in item.Customers)
        {
            var existingCustomer = await _context.Customers.FindAsync(ci.CustomerDNI);
            if (existingCustomer == null)
            {
                throw new Exception($"Customer with DNI {ci.CustomerDNI} not found");
            }

            existingItem.Customers.Add(new CustomerItem
            {
                CustomerDNI = ci.CustomerDNI,
                ItemCode = item.Code,
                Quantity = ci.Quantity,
                Date = ci.Date,
                CustomerObj = existingCustomer // Use the existing customer
            });
        }
        await _context.SaveChangesAsync();
    }

        public void DeleteItem(string code)
        {
            var item = _context.Items.Find(code);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
