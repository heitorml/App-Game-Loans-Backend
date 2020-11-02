using AppGameLoans.Domain.Dto;
using AppGameLoans.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AppGameLoans.Utilities.Extensions
{
    public static class AutomapperExtension
    {
        public static void AutomapperSettings(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutomapperExtension));
        }
    }
    public class ApplicationServiceAutoMapperProfile : Profile
    {
        public ApplicationServiceAutoMapperProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<GameDto, Game>();
            CreateMap<LoanDto, Loan>();
            CreateMap<FriendDto, Friend>();
        }
    }
}
