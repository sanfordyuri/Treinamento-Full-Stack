using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RXCrud.Data.Context;

namespace RXCrud.CrossCutting
{
    public static class InjectorDependencies
    {
        public static void RegisterDependencies(this IServiceCollection services, string defaultConnection)
        {
            services.AddDbContext<RXCrudContext>(options => options.UseNpgsql(defaultConnection));
            services.RegisterRepository();
            services.RegisterService();
        }
    }
}