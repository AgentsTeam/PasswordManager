using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PasswordManager.Common.Helpers;
using PasswordManager.Common.Models;

namespace PasswordManager.Common.Extensions
{
    public static class IocExtensions
    {
        public static void AddJwtServices(this IServiceCollection services, JwtSetting settings)
        {
            var events = new JwtBearerEvents()
            {
                // invoked when the token validation fails
                OnAuthenticationFailed = (context) =>
                {
                    Console.WriteLine(context.Exception);
                    return Task.CompletedTask;
                },

                // invoked when a request is received
                OnMessageReceived = (context) =>
                {
                    return Task.CompletedTask;
                },

                // invoked when token is validated
                OnTokenValidated = (context) =>
                {
                    return Task.CompletedTask;
                }
            };

            services.AddSingleton(settings);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = settings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(settings.IssuerSigningKey)),
                    ValidateIssuer = settings.ValidateIssuer,
                    ValidIssuer = settings.ValidIssuer,
                    ValidateAudience = settings.ValidateAudience,
                    ValidAudience = settings.ValidAudience,
                    RequireExpirationTime = settings.RequireExpirationTime,
                    ValidateLifetime = settings.RequireExpirationTime,
                    ClockSkew = TimeSpan.FromDays(1),
                };
                options.Events = events;
            });

            /*
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(options.DefaultPolicy).RequireAuthenticatedUser().Build();
            });
            */
        }

        public static void AddCommonServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
