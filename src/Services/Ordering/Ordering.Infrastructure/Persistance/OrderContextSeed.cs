using Microsoft.Extensions.Logging;
using Ordering.Doman.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistance
{
    public class OrderContextSeed
    {
        public static async  Task SeeAsync(OrderContext orderContext,ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogDebug("See database associated with context {DbContextName} ",typeof(OrderContext).Name);
            }
        }
        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() { UserName= "namAdm",FirstName ="nam",LastName="truong",EmailAddress="namtruong.it.dn@gmail.com",AddressLine="Da nang",Country = "Viet Nam",TotalPrice=500 }
            };
        }
    }
}
