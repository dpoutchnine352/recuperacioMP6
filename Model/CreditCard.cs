using System.ComponentModel.DataAnnotations;
namespace dpc.InternetSalesAPI
{
    public partial class CreditCard
    {
        [Key]
        public string CardNumber { get; set; }
        public string CardHolder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
    }
}