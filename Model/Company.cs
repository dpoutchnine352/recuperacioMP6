using System.ComponentModel.DataAnnotations;
namespace dpc.InternetSalesAPI
{
    public partial class Company
    {
        [Key]
        public string Name { get; set; }
    }
}