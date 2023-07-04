using DesafioDesenvolvimento.Data;
using DesafioDesenvolvimento.Data.Dtos;
using DesafioDesenvolvimento.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PessoaConnection");


builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<UsuarioDbContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("PessoaConnection")))
    .AddDbContext<PessoaContext>(opts => opts.UseSqlServer(builder.Configuration.GetConnectionString("PessoaConnection")));


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



//Add services to the container();

builder.Services
    .AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<UsuarioDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers().AddNewtonsoftJson();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DesafioDesenvolvimento", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

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
