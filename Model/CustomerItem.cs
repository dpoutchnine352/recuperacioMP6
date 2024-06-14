using System.Diagnostics.CodeAnalysis;

namespace dpc.InternetSalesAPI
{
    public partial class CustomerItem
    {
        public string CustomerDNI { get; set; }
        public string ItemCode { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        [AllowNull]
        public Customer? CustomerObj { get; set; }
        [AllowNull]
        public Item? ItemObj { get; set; }


    }
}
