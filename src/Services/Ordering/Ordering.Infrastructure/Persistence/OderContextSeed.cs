using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                 orderContext.Orders.AddRange(GetPreConfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("See Database associate with context {DbContextName}.", typeof(OrderContext).Name);
                    
            }
        }

        private static IEnumerable<Order> GetPreConfiguredOrders()
        {
            return new List<Order>
            {
                new Order {UserName = "swn", FirstName = "Mehmet", LastName = "Ozkaya", EmailAddress = "test@test.com", AddressLine = "Bahcelievler", Country="Turkey", TotalPrice = 350}
            };
        }
    }
}
