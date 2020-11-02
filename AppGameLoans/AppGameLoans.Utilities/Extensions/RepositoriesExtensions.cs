using AppGameLoans.Domain.Interfaces.Repositories;
using AppGameLoans.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AppGameLoans.Utilities.Extension
{
    public static class RepositoriesExtensions
    {
        public static void RepositoriesSettings(this IServiceCollection services)
        {
            services.AddTransient<ILoanRepository, LoanRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IFriendRepository, FriendRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
