using Autofac;
using Drin.Business.Mapping;
using Drin.Core.Services.EntityServices;
using Drin.Data;
using System.Reflection;
using Module = Autofac.Module;

namespace Drin.UI.Modules
{
    public class RepositoryServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var apiAssembly = Assembly.GetExecutingAssembly();

            var repoAssembly = Assembly.GetAssembly(typeof(DrinDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
            .Where(x => x.Name.EndsWith("Service"))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

            //TODO: Cacheleme şimdilik ertelendi.
            //builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();
        }
    }
}
