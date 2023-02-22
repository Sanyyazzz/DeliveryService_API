using DeliveryService_WebAPI.Models;
using DeliveryService_WebAPI.Providers;

var builder = WebApplication.CreateBuilder(args);
var defaultPolicy = "defaultPolicy";
// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: defaultPolicy,
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddDbContext<DeliveryServiceContext>();
builder.Services.AddScoped<IOrderManager, OrderManager>();

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

app.UseCors(defaultPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
