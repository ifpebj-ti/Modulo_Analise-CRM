using Microsoft.EntityFrameworkCore;
using Modelo.Analise.Api.Repository;
using Modelo.Analise.Api.Repository.implementation;
using Modelo.Analise.Api.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

//configuracao para context do banco de dados
builder.Services.AddDbContext<ContextBd>(options =>
    options.UseNpgsql(builder.Configuration["ConnectionStrings"])
);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IVendaRepository, VendaRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

//Adicionando cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "PolicyApp",
        policy =>
        {
            policy.WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();

        }

    );
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
//utilizando cors
app.UseCors("PolicyApp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
