using POS.Domain.Interfaces.Repositories;
using POS.Domain.Interfaces.Services;
using POS.Domain.Services;
using POS.Infra.Data.Context;
using POS.Infra.Data.Repository;
using SimpleInjector;

namespace POS.Infra.Cross.IoC
{
    public static class DIContainer
    {
        public static Container container;

        public static void RegisterDependencies(Container containerToInject)
        {
            containerToInject.Register<POSContext>(Lifestyle.Scoped);

            containerToInject.Register<ICategoryRepository, CategoryRepository>();
            containerToInject.Register<IProductRepository, ProductRepository>();
            containerToInject.Register<IPaymentMethodRepository, PaymentMethodRepository>();

            containerToInject.Register<ICategoryService, CategoryService>();
            containerToInject.Register<IProductService, ProductService>();
            containerToInject.Register<IPaymentMethodService, PaymentMethodService>();
        }
    }
}
