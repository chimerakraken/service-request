using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using service_request.Data;
using service_request.Mapper;
using AutoMapper;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<service_requestContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("service_requestContext") ?? throw new InvalidOperationException("Connection string 'service_requestContext' not found.")));

// Add services to the container.
builder.Services.AddAutoMapper(typeof(ServiceRequestMapper));

builder.Services.AddControllers()
      .AddJsonOptions(options =>
      {
          options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
      });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle^
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Service Request API", Version = "v1" });
    c.UseAllOfForInheritance();
    c.UseOneOfForPolymorphism();
    c.SchemaFilter<EnumSchemaFilter>(); // Custom schema filter to show enum as string
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
