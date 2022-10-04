using Drin.API.Extensions;
using Drin.API.Filters;
using Drin.API.Middlewares;
using Drin.Business.Mapping;
using Drin.Business.Services;
using Drin.Business.Services.EntityServices;
using Drin.Business.Validations;
using Drin.Core.Repositories;
using Drin.Core.Repositories.EntityRepositories;
using Drin.Core.Services;
using Drin.Core.Services.EntityServices;
using Drin.Core.UnitOfWorks;
using Drin.Data;
using Drin.Data.Repositories;
using Drin.Data.Repositories.EntityRepositories;
using Drin.Data.UnitOfWorks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
//var services = builder.Services;

//services.AddDependencyResolvers(configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped(typeof(NotFoundFilter<>));

//TODO : ServiceResponse'a göre düzenlemeler yapýlacak
//System.Text.Json.JsonException: A possible object cycle was detected.
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute()))
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining(typeof(ProductDTOValidator)));


//error verdiðinde kendi oluþturduðum modeli dönmesi için yazdým API için gerekli ama web uygulamasý için gerekli deðil
builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    opt.SuppressModelStateInvalidFilter = true;
});

//builder.Services.AddValidatorsFromAssemblyContaining(typeof(ProductDTOValidator));



builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddDbContext<DrinDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.CustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
