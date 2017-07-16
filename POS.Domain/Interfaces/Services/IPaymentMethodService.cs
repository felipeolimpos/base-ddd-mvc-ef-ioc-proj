using POS.Infra.Cross.DTO;
using System.Collections.Generic;

namespace POS.Domain.Interfaces.Services
{
    public interface IPaymentMethodService : IBaseService<PaymentMethodDTO>
    {
        IEnumerable<PaymentMethodDTO> GetAllActive();
    }
}
