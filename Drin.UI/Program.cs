using Autofac.Extensions.DependencyInjection;
using Autofac;
using Drin.Business.Mapping;
using Drin.UI.Extensions;
using Drin.UI.Modules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute()))
//    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining(typeof(ProductDTOValidator)));

var configuration = builder.Configuration;
var services = builder.Services;

services.AddDependencyResolvers(configuration);

services.AddEndpointsApiExplorer();
services.AddAutoMapper(typeof(MapProfile));
services.AddMemoryCache();

//AutoFac'ten dolayý eklendi
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepositoryServiceModule()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
