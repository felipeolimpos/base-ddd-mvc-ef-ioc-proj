using POS.Infra.Cross.IoC;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace POS.Web.App_Start
{
    public static class SimpleInjectorInitializer
    {
        public static void Initialize()
        {
            DIContainer.container = new Container();
            DIContainer.container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(DIContainer.container);

            DIContainer.container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(DIContainer.container));
        }

        private static void InitializeContainer(Container container)
        {
            DIContainer.RegisterDependencies(container);
        }
    }
}