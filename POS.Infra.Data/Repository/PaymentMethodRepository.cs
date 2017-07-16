using AutoMapper;
using POS.Domain.Entities;
using POS.Domain.Interfaces.Repositories;
using POS.Infra.Cross.DTO;
using System.Collections.Generic;
using System.Linq;

namespace POS.Infra.Data.Repository
{
    public class PaymentMethodRepository : BaseRepository<PaymentMethod, PaymentMethodDTO>, IPaymentMethodRepository
    {
        public IEnumerable<PaymentMethodDTO> GetAllActive()
        {
            var activeCategories = All().Where(c => c.Active).ToList();
            return Mapper.Map<List<PaymentMethodDTO>>(activeCategories);
        }
    }
}
