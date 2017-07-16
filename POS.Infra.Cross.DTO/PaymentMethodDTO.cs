using System;

namespace POS.Infra.Cross.DTO
{
    public class PaymentMethodDTO : IEntityDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}
