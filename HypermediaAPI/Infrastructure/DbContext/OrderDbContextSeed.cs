using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HypermediaAPI.Database
{
    public static class OrderDbContextSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OrderDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<OrderDbContext>>()))
            {
                context.Database.Migrate();
                // Look for any movies.
                if (context.ShoppingItem.Any())
                {
                    return;   // DB has been seeded
                }

                context.ShoppingItem.AddRange(
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "First item",
                        Price = 8.45d
                    },
                    new()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Second item",
                        Price = 23.4d
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
