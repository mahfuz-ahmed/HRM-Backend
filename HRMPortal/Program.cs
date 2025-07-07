
using HRM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using HRM.Applicatin;

var builder = WebApplication.CreateBuilder(args);

// Configure the application
builder.Configuration["Urls"] = "http://localhost:5000";

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<AppDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

// Register custom services for application and infrastructure layers
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure middleware and HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseRouting();
app.UseCors();
app.UseAuthorization();

// Map controllers
app.MapControllers();

// Run the application
app.Run();
