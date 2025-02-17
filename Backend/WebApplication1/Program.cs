using WebApplication1.Database;
using WebApplication1.Database.Impl;
using WebApplication1.Domains;
using WebApplication1.Domains.Impl;
using WebApplication1.Repositories;
using WebApplication1.Repositories.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IDBConnection, DBConnection>(provider =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new DBConnection(connectionString);
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IProductDomain, ProductDomain>();

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
