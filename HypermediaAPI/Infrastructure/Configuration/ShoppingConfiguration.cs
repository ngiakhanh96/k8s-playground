using HypermediaAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HypermediaAPI.Database.Configuration
{
    public class ShoppingConfiguration: IEntityTypeConfiguration<ShoppingItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingItem> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
