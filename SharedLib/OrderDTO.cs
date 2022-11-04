using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public string State { get; set; }
        public string OrderNumber { get; set; }
        public string EngineSpecification { get; set; }
        public string EngineSerialNumber { get; set; }
        public string EngineType1 { get; set; }
        public string EngineType2 { get; set; }
        public string Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
