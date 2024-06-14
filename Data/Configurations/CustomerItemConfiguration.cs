using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dpc.InternetSalesAPI {
    public class CustomerItemConfiguration : IEntityTypeConfiguration<CustomerItem>
    {
        public void Configure(EntityTypeBuilder<CustomerItem> builder)
        {
            builder.HasKey(ci => new { ci.ItemCode, ci.CustomerDNI, ci.Date });
            
            builder.HasOne(ci => ci.CustomerObj)
                .WithMany(c => c.Items)
                .HasForeignKey(ci => ci.CustomerDNI);
                
            builder.HasOne(ci => ci.ItemObj)
                .WithMany(i => i.Customers)
                .HasForeignKey(ci => ci.ItemCode);


        }
    }
}