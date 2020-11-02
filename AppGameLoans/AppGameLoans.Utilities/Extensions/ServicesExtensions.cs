using AppGameLoans.Domain.Interfaces.Services;
using AppGameLoans.Services.Services;
using Microsoft.Extensions.DependencyInjection;


namespace AppGameLoans.Utilities.Extension
{
    public static class ServicesExtensions
    {
        public static void ServicesSettings(this IServiceCollection services)
        {
            services.AddTransient<IFriendService, FriendService>();
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILoanService, LoanService>();
        }
    }
}
