using System.ComponentModel.DataAnnotations;
namespace dpc.InternetSalesAPI
{
    public partial class ShoppingCart
    {
        [Key]
        public int ShoppingCartId { get; set; }

    }
}