using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
namespace dpc.InternetSalesAPI
{
    public partial class Item
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        [AllowNull]
        public ICollection<CustomerItem> Customers { get; set; } 
    }
}