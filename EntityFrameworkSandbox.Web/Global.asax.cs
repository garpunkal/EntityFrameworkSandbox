using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using WebGrease.Css.Extensions;
using garpunkal.EntityFrameworkSandbox.Data;
using garpunkal.EntityFrameworkSandbox.Web.Modules;

namespace garpunkal.EntityFrameworkSandbox.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            EntityFrameworkSandboxDbContext.Initialize();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = InitialiseContainer();
            InitialiseAutoMapper();
        }

        private IContainer InitialiseContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();
            builder.RegisterModule(new DataModule());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }

        private void InitialiseAutoMapper()
        {
            var profileType = typeof(Profile);
            var profiles = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => profileType.IsAssignableFrom(t) && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(Activator.CreateInstance)
                .Cast<Profile>();

            Mapper.Initialize(a => profiles.ForEach(a.AddProfile));
            Mapper.AssertConfigurationIsValid();
        }
    }
}
