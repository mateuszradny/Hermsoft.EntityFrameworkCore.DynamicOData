using Hermsoft.EntityFrameworkCore.DynamicOData;
using Hermsoft.EntityFrameworkCore.DynamicOData.Services;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Data;
using Hermsoft.EntityFrameworkCore.DynamicOData.TestWebApi.Services.HR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<SalesDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestDbContext"))
);

builder.Services.AddDbContext<HRDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestDbContext"))
);

builder.Services.AddControllers()
    .AddDynamicOData<SalesDbContext>(options =>
    {
        options.RoutePrefix = "sales";
        options.IsEntityTypeAutorized = type => false;
    });

builder.Services.AddControllers()
    .AddDynamicOData<HRDbContext>(options =>
    {
        options.RoutePrefix = "hr";
        options.IsEntityTypeAutorized = type => false;
    });

builder.Services.AddScoped<IRequestHandlerService<HRDbContext>, HRRequestHandlerService>();

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

public partial class Program
{ }