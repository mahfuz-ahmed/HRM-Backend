
using HRM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using HRM.Applicatin;
using HRM.Applicatin.IRepository.Authentication;
using HRM.Infrastructure.Repository.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using HRM.Domain.Configuration;
using HRM.AP.Common.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configure the application
builder.Configuration["Urls"] = "http://localhost:5000";
var jwtSettings = builder.Configuration.GetSection("Jwt");
builder.Services.Configure<JwtSettings>(jwtSettings);

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

builder.Services.AddScoped<ITokenService, TokenService>();

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

// Register authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // Set to true in production
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]!))
    };
});

builder.Services.AddAuthorization();


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
app.UseGlobalExceptionMiddleware();
app.UseAuthentication();
app.UseAuthorization();

// Map controllers
app.MapControllers();

// Run the application
app.Run();
