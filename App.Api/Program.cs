using App.Api.Filters;
using App.Api.Middlewares;
using App.Api.Modules;
using App.Core.Repositories;
using App.Core.Services;
using App.Core.UnitOfWorks;
using App.Repository;
using App.Repository.Repositories;
using App.Repository.UnitOfWorks;
using App.Service.Mapping;
using App.Service.Services;
using App.Service.Validations;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//FluentValidation Ekledik.
builder.Services.AddControllers(options => { options.Filters.Add(new ValidateFilterAttribute());}).AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<CustomerDtoValidator>());
//kendi validate modelimizi döndürmek için apinin modelini baskýlýyoruz
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Genericleri ,AutoMapper ve Unitofworku ekleme iþlemi
builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddAutoMapper(typeof(MapProfile));


//Sql yolu belirleme ve appdbcontextin yolunu verme.
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), Option =>
    {
        Option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});


builder.Host.UseServiceProviderFactory
    (new AutofacServiceProviderFactory ());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder=>containerBuilder.RegisterModule(new RepoServiceModule()));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UserCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
