
using AppGameLoans.Domain.Entities;
using AppGameLoans.Domain.Enum;
using System;
using Xunit;

namespace AppGameLoans.Tests.Models
{
    public class UserTest
    {
        public UserTest() {}

        [Fact]
        public void EmailInvalid()
        {
  
            User user = new User();
            user.Email = "app";
            user.Name = "Test";
            user.Role = Role.Admin;
            Assert.Equal("app@email.com", user.Email);
        }

        [Fact]
        public void EmailValid()
        {
            User user = new User();
            user.Email = "app@email.com";
            user.Name = "Test";
            user.Role = Role.Admin;
            Assert.Equal("app@email.com", user.Email);

        }
    }
}
