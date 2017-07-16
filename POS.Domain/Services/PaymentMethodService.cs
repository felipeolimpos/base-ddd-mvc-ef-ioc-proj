using System;
using System.Collections.Generic;
using POS.Domain.Entities;
using POS.Domain.Interfaces.Repositories;
using POS.Domain.Interfaces.Services;
using POS.Infra.Cross.DTO;

namespace POS.Domain.Services
{
    public class PaymentMethodService : BaseService<PaymentMethod, PaymentMethodDTO>, IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository) : base(paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public IEnumerable<PaymentMethodDTO> GetAllActive()
        {
            return _paymentMethodRepository.GetAllActive();
        }
    }
}
