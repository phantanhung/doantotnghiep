using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using FoodOrderSolution.Business.Core;
using FoodOrderSolution.Services;
using FoodOrderSolution.Services.Infrastructure;
using FoodOrderSolution.Services.Repositories;
using Microsoft.Owin;
using Owin;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(FoodOrderSolution.Server.App_Start.Startup))]
namespace FoodOrderSolution.Server.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
        }
        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UnitOfWork>().As<UnitOfWork>();
            builder.RegisterType<IDbFactory>().As<IDbFactory>();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<EntitiesDbContext>().AsSelf().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(VendorRepository).Assembly)
                .Where(t => t.Name.Contains("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(VendorBusiness).Assembly)
               .Where(t => t.Name.Contains("Business"))
               .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver

        }
    }
}