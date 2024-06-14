using System.ComponentModel.DataAnnotations;
namespace dpc.InternetSalesAPI
{
    public partial class Shipping
    {
        [Key]
        public int ShippingId { get; set; }
    }
}