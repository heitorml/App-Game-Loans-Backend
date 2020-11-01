using AppGameLoans.Domain.Interface;
using AppGameLoans.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace AppGameLoans.Utilities.Extension
{
    public static class RepositoriesExtension
    {
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IFriendRepository, FriendRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
