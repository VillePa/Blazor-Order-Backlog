using System.ComponentModel.DataAnnotations;

namespace OrderBacklogApi.Data
{
    public class Order
    {
        public Guid Id { get; set; }


        public string State { get; set; }

        [Required]
        public string OrderNumber { get; set; }

        [Required]
        public string EngineSpecification { get; set; }

        [Required]
        public string EngineSerialNumber { get; set; }

        [Required]
        public string EngineType1 { get; set; }

        [Required]
        public string EngineType2 { get; set; }

        public string Customer { get; set; }

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime DeliveryDate { get; set; } = DateTime.Now;

    }
}
