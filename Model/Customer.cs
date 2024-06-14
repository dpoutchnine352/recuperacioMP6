using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
namespace dpc.InternetSalesAPI
{
    public partial class Customer
    {
        [Key]
        public string DNI { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        [AllowNull]
        public ICollection<CustomerItem> Items { get; set; } 
    }

}
