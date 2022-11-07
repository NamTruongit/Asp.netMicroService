using Microsoft.EntityFrameworkCore;
using Ordering.Doman.Common;
using Ordering.Doman.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistance
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) :base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "nam";
                        break;
                    case EntityState.Modified:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "nam";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
