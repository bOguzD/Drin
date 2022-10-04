using Autofac;
using Autofac.Extensions.DependencyInjection;
using Drin.API.Extensions;
using Drin.API.Middlewares;
using Drin.API.Modules;
using Drin.Business.Mapping;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddDependencyResolvers(configuration);

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddAutoMapper(typeof(MapProfile));

//AutoFac'ten dolayý eklendi
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepositoryServiceModule()));


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
