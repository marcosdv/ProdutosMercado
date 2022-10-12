using Microsoft.EntityFrameworkCore;
using ProdutosMercado.Domain.Handlers;
using ProdutosMercado.Domain.Repositories;
using ProdutosMercado.Infra.Contexts;
using ProdutosMercado.Infra.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//DI
//builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("connectionString")));

builder.Services.AddTransient<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<FornecedorHandler, FornecedorHandler>();
builder.Services.AddTransient<ProdutoHandler, ProdutoHandler>();
//DI

//EVITAR CICLOS JSON
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler =
        ReferenceHandler.IgnoreCycles
);

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


app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);


app.UseAuthorization();

app.MapControllers();

app.Run();