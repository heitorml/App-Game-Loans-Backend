using Microsoft.Extensions.Configuration;
using AppGameLoans.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace AppGameLoans.Utilities.Extension
{
    public static class  DbContextExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GameLoansDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                sqlServerOptionsAction : sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure();
                }));
           
       
        }
    }
}
