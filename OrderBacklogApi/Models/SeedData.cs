using Microsoft.EntityFrameworkCore;
using OrderBacklogApi.Data;

namespace OrderBacklogApi.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new OrderContext(
            serviceProvider.GetRequiredService<
                    DbContextOptions<OrderContext>>()))
            {
                if (context == null)
                {
                    throw new ArgumentNullException("Null QuoteContext");
                }

                context.Database.EnsureCreated();


                if (context.Orders.Any())
                {
                    return;   // DB has been seeded
                              // To re-seed the db: delete the existing *.db file and let the app create a new one
                }

                context.Orders.AddRange(
                   new Order
                   {
                       Id = Guid.NewGuid(),
                       State = "not started",
                       OrderNumber = "12345/1",
                       EngineSpecification = "835299819",
                       EngineSerialNumber = "FRT12335",
                       EngineType1 = "3000",
                       EngineType2 = "CFX",
                       Customer = "Cust1",
                       OrderDate = DateTime.Now,
                       DeliveryDate = DateTime.Now,
                   },
                   new Order
                   {
                       Id = Guid.NewGuid(),
                       State = "not started",
                       OrderNumber = "12345/1",
                       EngineSpecification = "835299819",
                       EngineSerialNumber = "FRT12888",
                       EngineType1 = "3500",
                       EngineType2 = "CFX",
                       Customer = "Cust1",
                       OrderDate = DateTime.Now,
                       DeliveryDate = DateTime.Now,
                   },
                   new Order
                   {
                       Id = Guid.NewGuid(),
                       State = "finished",
                       OrderNumber = "12345/1",
                       EngineSpecification = "835299819",
                       EngineSerialNumber = "FRT64346",
                       EngineType1 = "4000",
                       EngineType2 = "CFX",
                       Customer = "Cust1",
                       OrderDate = DateTime.Now,
                       DeliveryDate = DateTime.Now,
                   },
                   new Order
                   {
                       Id = Guid.NewGuid(),
                       State = "dismantle/cleaning",
                       OrderNumber = "12345/1",
                       EngineSpecification = "835299819",
                       EngineSerialNumber = "FRT23542",
                       EngineType1 = "6000",
                       EngineType2 = "QCR",
                       Customer = "Cust1",
                       OrderDate = DateTime.Now,
                       DeliveryDate = DateTime.Now,
                   },
                   new Order
                   {
                       Id = Guid.NewGuid(),
                       State = "assembly",
                       OrderNumber = "12345/1",
                       EngineSpecification = "12345X",
                       EngineSerialNumber = "FRT98785",
                       EngineType1 = "7000",
                       EngineType2 = "Proto",
                       Customer = "CustX",
                       OrderDate = DateTime.Now,
                       DeliveryDate = DateTime.Now,
                   },
                   new Order
                   {
                       Id = Guid.NewGuid(),
                       State = "assembly",
                       OrderNumber = "12345/1",
                       EngineSpecification = "835299819",
                       EngineSerialNumber = "FRT54367",
                       EngineType1 = "3520 ",
                       EngineType2 = "CFX",
                       Customer = "Cust3",
                       OrderDate = DateTime.Now,
                       DeliveryDate = DateTime.Now,
                   }


                );
                context.SaveChanges();
            }
        }
    }
}
