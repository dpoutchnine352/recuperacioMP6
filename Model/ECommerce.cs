using System.ComponentModel.DataAnnotations;
namespace dpc.InternetSalesAPI
{
    public partial class ECommerce
    {
        [Key]
        public int ECommerceId { get; set; }
    }
}