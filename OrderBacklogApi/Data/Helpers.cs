using SharedLib;
using System.Runtime.CompilerServices;

namespace OrderBacklogApi.Data
{
    public static class Helpers
    {
        public static OrderDTO ToDTO(this Order item)
        {
            return new OrderDTO
            {
                Id = item.Id,
                State = item.State,
                OrderNumber = item.OrderNumber,
                EngineSpecification = item.EngineSpecification,
                EngineSerialNumber = item.EngineSerialNumber,
                EngineType1 = item.EngineType1,
                EngineType2 = item.EngineType2,
                Customer = item.Customer,
                OrderDate = item.OrderDate,
                DeliveryDate = item.DeliveryDate
            };
        }
    }
}
