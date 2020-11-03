using AppGameLoans.Domain.Dto;
using AppGameLoans.Domain.Helpers;
using AppGameLoans.Domain.Interfaces.Repositories;
using AppGameLoans.Services.Services;
using AutoMapper;
using Moq;
using System;
using Xunit;

namespace AppGameLoans.Tests.Services
{
    public class UserServiceTest
    {
        public UserServiceTest()
        {
                
        }

        [Fact]
        public async void InsertUserValid()
        {
            UserDto user = new UserDto();
            user.Name = "User Test";
            user.Email = "app@app.com";

            Mock<IUserRepository> moqRep = new Mock<IUserRepository>();
            Mock<IMapper> moqMapper = new Mock<IMapper>();

            UserService service = new UserService(moqRep.Object, moqMapper.Object);

            Result result = await service.AddNewUser(user);

            Assert.True(result.HasSuccess);

        }

        [Fact]
        public async void InsertUserInvalid()
        {
            UserDto user = new UserDto();


            Mock<IUserRepository> moqRep = new Mock<IUserRepository>();
            Mock<IMapper> moqMapper = new Mock<IMapper>();
            UserService service = new UserService(moqRep.Object, moqMapper.Object);

            Result result = await service.AddNewUser(user);

            Assert.False(result.HasSuccess);

        }

        [Fact]
        public async void UpdateUserInvalid()
        {
            UserDto user = new UserDto();


            Mock<IUserRepository> moqRep = new Mock<IUserRepository>();
            Mock<IMapper> moqMapper = new Mock<IMapper>();
            UserService service = new UserService(moqRep.Object, moqMapper.Object);

            Result result = await service.UpdateUser(user);

            Assert.False(!result.HasSuccess);

        }

        [Fact]
        public async void DeleteUserValid()
        {
            Mock<IUserRepository> moqRep = new Mock<IUserRepository>();
            Mock<IMapper> moqMapper = new Mock<IMapper>();
            UserService service = new UserService(moqRep.Object, moqMapper.Object);
            Guid id = Guid.NewGuid();

            Result result = await service.DeleteUser(id);

            Assert.True(result.HasSuccess);
        }
    }
}
