using Drin.API.Filters;
using Drin.Business.Mapping;
using Drin.Business.Services;
using Drin.Business.Validations;
using Drin.Core.Repositories;
using Drin.Core.Services;
using Drin.Core.UnitOfWorks;
using Drin.Data;
using Drin.Data.Repositories;
using Drin.Data.UnitOfWorks;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Drin.API.Extensions
{
    public static class DependencyResolverExtension
    {
        internal static void AddDependencyResolvers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped(typeof(NotFoundFilter<>));

            services.AddDbContext<DrinDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //TODO : ServiceResponse'a göre düzenlemeler yapılacak
            //System.Text.Json.JsonException: A possible object cycle was detected.
            services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute()))
                    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining(typeof(ProductDTOValidator)));

            //error verdiğinde kendi oluşturduğum modeli dönmesi için yazdım API için gerekli ama web uygulaması için gerekli değil
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });
        }
    }
}
