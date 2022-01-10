using PasswordManager.Domain.Contracts;
using PasswordManager.Persistence;

namespace PasswordManager.Api.Helpers
{
    public static class IocHelper
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordManagerRepository,PasswordManagerRepository>();
        }
    }
}
