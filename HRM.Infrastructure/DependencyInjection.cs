﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using HRM.Applicatin;
using StackExchange.Redis;
using HRM.Applicatin.Service;
using HRM.Infrastructure.Service;

namespace HRM.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager config)
        {
            services
                //.AddAuth(config)
                .AddPersistence(config);
            return services;
        }
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IHolidaysRepository, HolidaysRepository>();
            services.AddScoped<IDesignationRepository, DesignationRepository>();
            services.AddScoped<IEducationHistoryRepository, EducationHistoryRepository>();
            services.AddScoped<IAttendanceStatusRepository, AttendanceStatusRepository>();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<IBankInformationRepository, BankInformationRepository>();
            services.AddScoped<IPaySlipRepository, PaySlipRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IEmployeeAttendanceRepository, EmployeeAttendanceRepository>();
            services.AddScoped<IEmployeeDetailsRepository, EmployeeDetailsRepository>();

            var redisConnectionString = configuration["Redis:ConnectionString"];
            services.AddSingleton<StackExchange.Redis.IConnectionMultiplexer>(ConnectionMultiplexer.Connect(redisConnectionString));
            services.AddSingleton<IRedisCacheService, RedisCacheService>();

            //services.AddSingleton<IConnectionMultiplexer>(sp =>
            //{
            //    var config = sp.GetRequiredService<IConfiguration>();
            //    var redisConnection = config["Redis:ConnectionString"];
            //    return ConnectionMultiplexer.Connect(redisConnection);
            //});

            return services;
        }
        public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager config)
        {
            //var jwtSettings = new JwtSettings();
            //config.Bind(JwtSettings.JWT_SectionName, jwtSettings);
            //services.AddSingleton(Options.Create(jwtSettings));

            //services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddAuthentication(option =>
            {
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()//new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = config["Jwt:Issuer"],
                        ValidAudience = config["Jwt:Issuer"],
                    };
                });

            services.AddAuthorization();
            return services;
        }
    }
}
