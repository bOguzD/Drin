using Drin.Business.Mapping;
using Drin.Business.Services;
using Drin.Business.Services.EntityServices;
using Drin.Core.Repositories;
using Drin.Core.Repositories.EntityRepositories;
using Drin.Core.Services;
using Drin.Core.Services.EntityServices;
using Drin.Core.UnitOfWorks;
using Drin.Data;
using Drin.Data.Repositories;
using Drin.Data.Repositories.EntityRepositories;
using Drin.Data.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();


//TODO : ServiceResponse'a göre düzenlemeler yapýlacak
//System.Text.Json.JsonException: A possible object cycle was detected.
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddAutoMapper(typeof(MapProfile));

//builder.Services.AddDbContext<DrinDbContext>(x =>
//{
//    x.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"), options =>
//    {
//        options.MigrationsAssembly(Assembly.GetAssembly(typeof(DrinDbContext)).GetName().Name);
//    });
//});

builder.Services.AddDbContext<DrinDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
