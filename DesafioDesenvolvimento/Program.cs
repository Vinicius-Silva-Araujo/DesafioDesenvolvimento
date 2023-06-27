using DesafioDesenvolvimento.Data;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("PessoaConnection");


//builder.Services.AddDbContext<PessoaContext>(opts =>
// opts.UseSqlServer(connectionString));
builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<PessoaContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString
                    ("PessoaConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


//Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
