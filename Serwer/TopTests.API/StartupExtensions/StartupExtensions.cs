using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopTests.API.HUB;
using TopTests.DAL;
using TopTests.DAL.Entities;
using TopTests.DAL.Interfaces;
using TopTests.DAL.Repositories;
using TopTests.Services.Interfaces;
using TopTests.Services.Mapper;
using TopTests.Services.Services;

namespace TopTests.API.StartupExtensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            return services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString)
            .EnableSensitiveDataLogging());
        }
        public static IServiceCollection AddMappingServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<Profile, AuthorizeProfile>()
                .AddSingleton<Profile, SubjectProfile>()
                .AddSingleton<Profile, FileProfile>()
                .AddSingleton<IConfigurationProvider, AutoMapperConfiguration>(p =>
                    new AutoMapperConfiguration(p.GetServices<Profile>()))
                .AddSingleton<IMapper, Mapper>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<ITestService, TestService>();
            services.AddScoped<ICheckTestService, CheckTestService>();
            services.AddScoped<ITestQuestionsService, TestQuestionsService>();
            services.AddScoped<ITimeRemainingService, TimeRemainingService>();
            services.AddScoped<IFeedBackService, FeedBackService>();
            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IRefreshRepository, RefreshRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<ITestQuestionRepository, TestQuestionsRepository>();
            services.AddScoped<IAnswersRepository, AnswersRepository>();
            services.AddScoped<IResultsRepository, ResultsRepository>();
            services.AddScoped<ITimeRemainingRepository, TimeRemainingRepository>();
            services.AddScoped<IFeedBackRepository, FeedBacksRepository>();
            return services;
        }
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "Roles",
                    ValidateIssuer = true,
                    ValidIssuer = TokenOptions.ISSUER,
                    ValidAudience = TokenOptions.AUDIENCE,
                    ValidateLifetime = true,
                    IssuerSigningKey = TokenOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true
                };
                });

            return services;
        }
    }
}
