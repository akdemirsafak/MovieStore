
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CONTEXT VE AUTOMAPPER GİBİ ŞEYLERİN BUILDER BUILD EDİLMEDEN DAHİL EDİLMESİ LAZIM.
builder.Services.AddDbContext<MovieStoreDbContext>(option => option.UseInMemoryDatabase(databaseName: "MovieStoreDB"));
builder.Services.AddScoped<IMovieStoreDbContext>(provider => provider.GetService<MovieStoreDbContext>());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


var app = builder.Build();

//InMemory e özel uygulama her çalıştığında örnek veriler eklemek için.
using (var scope = app.Services.CreateScope())
{
    var Services = scope.ServiceProvider;

    DataGenerator.Initialize(Services);
}



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
