using Drin.Business.Mapping;
using Drin.Business.Services;
using Drin.Business.Services.EntityServices;
using Drin.Core.Repositories;
using Drin.Core.Services;
using Drin.Core.Services.EntityServices;
using Drin.Core.UnitOfWorks;
using Drin.Data;
using Drin.Data.Repositories;
using Drin.Data.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));


builder.Services.AddTransient<IProductService, ProductService>();



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
