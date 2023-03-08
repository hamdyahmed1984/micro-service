using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.SyncDataServices.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
if(builder.Environment.IsProduction())
{
    Console.WriteLine("---> Using SQL Server database.");
    builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ProductsConn")));
}
else
{
    Console.WriteLine("---> Using InMemory database.");
    builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("InMemoryDB"));
}

builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddHttpClient<IOrderDataClient, HttpOrderDataClient>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

DbSeed.SeedData(app, builder.Environment.IsProduction());

app.Run();
