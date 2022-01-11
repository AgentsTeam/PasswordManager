using PasswordManager.Domain.Contracts;
using PasswordManager.Persistence;
using PasswordManager.Service;

namespace PasswordManager.Api.Helpers
{
    public static class IocHelper
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordManagerRepository,PasswordManagerRepository>();

            services.AddScoped<ProperyService>();
        }
    }
}
