using Diplomska.Persistence;
using Diplomska.Persistence.Services;
using Diplomska.Persistence.Services.Interfaces;
using Diplomska.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IUnopenedProductService, UnopenedProductService>();
builder.Services.AddTransient<IOpenProductService, OpenProductService>();
builder.Services.AddTransient<IFridgeService, FridgeService>();
builder.Services.AddDbContext<DataContext>();

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
DatabaseSeeder.SeedDatabase(app.Services);

app.Run();