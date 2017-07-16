using POS.Domain.Interfaces.Services;
using POS.Infra.Cross.DTO;
using POS.Web.ViewModels;

namespace POS.Web.Controllers
{
    public class PaymentMethodsController : EntityBaseController<IPaymentMethodService, PaymentMethodDTO, PaymentMethodViewModel>
    {
        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentMethodsController(IPaymentMethodService paymentMethodService) : base(paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }
    }
}
