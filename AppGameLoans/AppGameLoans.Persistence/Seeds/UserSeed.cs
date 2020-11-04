using AppGameLoans.Domain.Entities;
using AppGameLoans.Services.Util;
using System.Collections.Generic;


namespace AppGameLoans.Persistence.Seeds
{
    public static class UserSeed
    {
        public static List<User> DefaultUsers()
        {
            string passwordDefault = "user123";
            var userList = new List<User>() {
                new User()
                {
                    Email= "usertest@test.com",
                    Password = SecurityUtil.GenerateSHA256Hash(passwordDefault),
                    Name = "User Test"
                }
            };
            return userList;
        }
    }
}
