using System.ComponentModel.DataAnnotations;
namespace dpc.InternetSalesAPI
{
    public partial class Order
    {
        [Key]
        public int OrderNumber { get; set; }
    }
}